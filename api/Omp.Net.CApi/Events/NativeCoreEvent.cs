using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Events;

internal delegate void OnReadyDelegate();

internal static partial class NativeCoreEvent
{
	public static event OnReadyDelegate? NativeOnReady;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnReady()
	{
		NativeOnReady?.Invoke();
	}
}
