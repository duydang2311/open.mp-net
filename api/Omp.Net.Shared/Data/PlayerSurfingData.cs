using System.Numerics;

namespace Omp.Net.Shared.Data;

public readonly record struct PlayerSurfingData
{
	public enum SurfingType
	{
		None,
		Vehicle,
		Object,
		PlayerObject
	}
	public readonly SurfingType Type { get; init; }
	public readonly int Id { get; init; }
	public readonly Vector3 Offset { get; init; }

	public readonly override string ToString()
	{
		return $"({Type}, {Id}, {Offset})";
	}
};
