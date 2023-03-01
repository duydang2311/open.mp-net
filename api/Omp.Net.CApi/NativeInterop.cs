using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: InternalsVisibleTo("Omp.Net")]
[assembly: InternalsVisibleTo("Omp.Net.Core")]
namespace Omp.Net.CApi;

public delegate void MainDelegate();

internal static class NativeInterop
{
	public const string DllName = "libomp-net";
	public const CallingConvention NativeCallingConvetion = CallingConvention.Cdecl;
}
