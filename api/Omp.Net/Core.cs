using System.Runtime.InteropServices;
using Omp.Net.CApi.Natives;
using Omp.Net.Entities.Player;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Threading;

namespace Omp.Net;

public sealed class Core
{
	public static Core Instance { get; private set; } = null!;

	internal Core(BaseEntry entry)
	{
		Instance = this;
		tickSchedulerFactory = entry.GetTickSchedulerFactory();
		playerFactory = entry.GetPlayerFactory();
		textDrawFactory = entry.GetTextDrawFactory();
		tickScheduler = tickSchedulerFactory.Create(Thread.CurrentThread);

		tickDelegate = tickScheduler.Tick;
		CoreNative.Core_SetTickDelegate(Marshal.GetFunctionPointerForDelegate(tickDelegate));
	}

	public IPlayerFactory GetPlayerFactory()
	{
		return playerFactory;
	}

	public ITextDrawFactory GetTextDrawFactory()
	{
		return textDrawFactory;
	}

	public void Invoke(Action action)
	{
		tickScheduler.Schedule(action);
	}

	public Task InvokeAsync(Func<Task> func)
	{
		return tickScheduler.ScheduleAsync(func);
	}

	public Task<T> InvokeAsync<T>(Func<Task<T>> func)
	{
		return tickScheduler.ScheduleAsync(func);
	}

	private delegate void TickDelegate();
	private readonly ITickScheduler tickScheduler;
	private readonly TickDelegate tickDelegate;
	private readonly ITickSchedulerFactory tickSchedulerFactory;
	private readonly IPlayerFactory playerFactory;
	private readonly ITextDrawFactory textDrawFactory;
}
