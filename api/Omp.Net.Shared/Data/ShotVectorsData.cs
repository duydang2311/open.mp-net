using System.Numerics;

namespace Omp.Net.Shared.Data;

public readonly record struct ShotVectorsData
{
	public readonly Vector3 Origin { get; init; }
	public readonly Vector3 Hit { get; init; }

	public ShotVectorsData(Vector3 origin, Vector3 hit)
	{
		Origin = origin;
		Hit = hit;
	}

	public ShotVectorsData(float originX, float originY, float originZ, float hitX, float hitY, float hitZ) : this(new Vector3(originX, originY, originZ), new Vector3(hitX, hitY, hitZ)) { }

	public readonly override string ToString()
	{
		return $"({Origin}, {Hit})";
	}
}
