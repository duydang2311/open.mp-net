namespace Omp.Net.Shared;

public readonly record struct WeaponSlotData
{
	public readonly byte Id { get; init; }
	public readonly uint Ammo { get; init; }

	public readonly override string ToString()
	{
		return $"({Id}, {Ammo})";
	}
}
