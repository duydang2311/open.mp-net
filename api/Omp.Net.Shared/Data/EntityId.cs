namespace Omp.Net.Shared;

public readonly record struct EntityId
{
	public readonly IntPtr NativeHandle { get; }
	public readonly int Id { get; }

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
