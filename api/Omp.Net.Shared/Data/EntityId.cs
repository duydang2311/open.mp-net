using System.Runtime.InteropServices;

namespace Omp.Net.Shared;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct EntityId
{
	public readonly IntPtr NativeHandle { get; init; }
	public readonly int Id { get; init; }

	public EntityId(IntPtr nativeHandle, int id)
	{
		NativeHandle = nativeHandle;
		Id = id;
	}

	public override readonly string ToString()
	{
		return $"({NativeHandle}, {Id})";
	}
}
