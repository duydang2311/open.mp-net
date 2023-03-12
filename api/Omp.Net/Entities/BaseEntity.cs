using System.Numerics;
using static Omp.Net.CApi.Natives.EntityNative;

namespace Omp.Net.Entities;

public abstract class BaseEntity : IEntity
{
	public virtual IntPtr NativeHandle { get; }

	public virtual int Id { get; }

	public virtual Vector3 Position
	{
		get => Entity_GetPosition(NativeHandle);
		set => Entity_SetPosition(NativeHandle, value);
	}

	public virtual Vector3 Rotation
	{
		get => Entity_GetRotation(NativeHandle);
		set => Entity_SetRotation(NativeHandle, value);
	}

	public virtual int VirtualWorld
	{
		get => Entity_GetVirtualWorld(NativeHandle);
		set => Entity_SetVirtualWorld(NativeHandle, value);
	}

	public BaseEntity(IntPtr nativeHandle, int id)
	{
		NativeHandle = nativeHandle;
		Id = id;
	}
}
