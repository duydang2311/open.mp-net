#if !NET7_0_OR_GREATER
using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Natives;

internal static partial class PlayerNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_GetName(int playerid, IntPtr ptr, int size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Player_SetName(int playerid, [MarshalAs(UnmanagedType.LPStr)] string name);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetSpawnInfo(int playerid, int team, int skin, float x, float y, float z, float rotation, int weapon1, int weapon1_ammo, int weapon2, int weapon2_ammo, int weapon3, int weapon3_ammo);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_Spawn(int playerid);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetPosition(int playerid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetPositionFindZ(int playerid, float x, float y, float z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public unsafe static extern bool Player_GetPosition(int playerid, float* x, float* y, float* z);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_SetFacingAngle(int playerid, float angle);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public unsafe static extern bool Player_GetFacingAngle(int playerid, float* angle);
}
#endif
