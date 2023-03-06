using System.Runtime.InteropServices;

namespace Omp.Net.CApi;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct UnmanagedEntityId
{
	public readonly IntPtr NativeHandle;
	public readonly int Id;
}
