using System.Numerics;

namespace Omp.Net.Shared.Data;

public readonly record struct UnoccupiedVehicleUpdateData
{
	public readonly byte Seat { get; init; }
	public readonly Vector3 Position { get; init; }
	public readonly Vector3 Velocity { get; init; }

	public readonly override string ToString()
	{
		return $"({Seat}, {Position}, {Velocity})";
	}
};
