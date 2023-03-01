using System.Runtime.InteropServices;
using Omp.Net.CApi.Natives;
using Omp.Net.Threading;

namespace Omp.Net;

public class Core : ICore
{
	private delegate void TickDelegate();

	private readonly ITickScheduler tickScheduler;
	private readonly TickDelegate tickDelegate;

	public Core(ITickSchedulerFactory tickSchedulerFactory)
	{
		tickScheduler = tickSchedulerFactory.Create(Thread.CurrentThread);
		tickDelegate = tickScheduler.Tick;

		CoreNative.Core_SetTickDelegate(Marshal.GetFunctionPointerForDelegate(tickDelegate));
	}

	public void Invoke(Action action)
	{
		tickScheduler.Schedule(action);
	}
}
