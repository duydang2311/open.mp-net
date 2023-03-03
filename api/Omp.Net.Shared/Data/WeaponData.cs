using System.Numerics;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Shared.Data;

public readonly record struct WeaponData
{
	public readonly PlayerWeapon Weapon { get; init; }
	public readonly int Ammo { get; init; }

	public WeaponData(PlayerWeapon weapon, int ammo)
	{
		Weapon = weapon;
		Ammo = ammo;
	}

	public readonly override string ToString()
	{
		return $"({Weapon}, {Ammo})";
	}
}
