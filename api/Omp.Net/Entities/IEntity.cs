using System.Numerics;

namespace Omp.Net.Entities;

public interface IEntity
{
	int Id { get; }
	IntPtr NativeHandle { get; }
	Vector3 Position { get; set; }
	Vector3 Rotation { get; set; }
	int VirtualWorld { get; set; }
}
