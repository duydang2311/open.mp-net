using System.Numerics;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Shared.Data;

public readonly record struct PlayerAimData
{
	public readonly Vector3 CamFrontVector { get; init; }
	public readonly Vector3 CamPos { get; init; }
	public readonly float AimZ { get; init; }
	public readonly float CamZoom { get; init; }
	public readonly float AspectRatio { get; init; }
	public readonly PlayerWeaponState WeaponState { get; init; }
	public readonly byte CamMode { get; init; }

	public readonly override string ToString()
	{
		return $"({CamFrontVector}, {CamPos}, {AimZ}, {CamZoom}, {AspectRatio}, {WeaponState}, {CamMode})";
	}
};
