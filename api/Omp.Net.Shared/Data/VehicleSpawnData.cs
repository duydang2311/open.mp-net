using System.Numerics;
using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VehicleSpawnData
{
	public readonly long RespawnDelay { get; init; }
	public readonly int ModelID { get; init; }
	public readonly Vector3 Position { get; init; }
	public readonly float ZRotation { get; init; }
	public readonly int Color1 { get; init; }
	public readonly int Color2 { get; init; }
	public readonly bool Siren { get; init; }
	public readonly int Interior { get; init; }

	public override readonly string ToString()
	{
		return $"({RespawnDelay}, {ModelID}, {Position}, {ZRotation}, {Color1}, {Color2}, {Siren}, {Interior})";
	}
};

