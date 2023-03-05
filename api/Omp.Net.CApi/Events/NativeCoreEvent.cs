using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Events;

public delegate void ReadyDelegate();

public static partial class NativeCoreEvent
{
	public static event ReadyDelegate? ReadyEvent;

	[UnmanagedCallersOnly()]
	private static void Ready()
	{
		ReadyEvent?.Invoke();
	}
}
