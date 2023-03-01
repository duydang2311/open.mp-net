#if NET7_0_OR_GREATER
using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Natives;

internal static partial class PlayerNative
{
	[LibraryImport(NativeInterop.DllName, EntryPoint = "Player_GetName")]
	public static partial bool GetName(int playerid, IntPtr ptr, int size);

	[LibraryImport(NativeInterop.DllName, EntryPoint = "Player_SetName")]
	public static partial int SetName(int playerid, [MarshalAs(UnmanagedType.LPStr)] string name);

	[LibraryImport(NativeInterop.DllName, EntryPoint = "Player_Spawn")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static partial bool Spawn(int playerid);
}
#endif
