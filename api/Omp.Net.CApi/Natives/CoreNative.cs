using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Natives;

internal static class CoreNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Core_SetTickDelegate(IntPtr delegatePointer);
}
