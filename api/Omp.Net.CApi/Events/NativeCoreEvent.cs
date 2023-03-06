using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Events;

public delegate void OnReadyDelegate();

public static partial class NativeCoreEvent
{
	public static event OnReadyDelegate? NativeOnReady;

	[UnmanagedCallersOnly()]
	private static void OnReady()
	{
		NativeOnReady?.Invoke();
	}
}
