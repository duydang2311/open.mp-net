using System.Numerics;
using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Natives;

internal static class EntityNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Entity_GetPosition(IntPtr entity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Entity_SetPosition(IntPtr entity, Vector3 position);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Entity_GetRotation(IntPtr entity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Entity_SetRotation(IntPtr entity, Vector3 rotation);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Entity_GetVirtualWorld(IntPtr entity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Entity_SetVirtualWorld(IntPtr entity, int vw);
}
