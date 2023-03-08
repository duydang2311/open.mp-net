using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct PlayerBulletData
{
	private readonly Vector3 Origin { get; init; }
	private readonly Vector3 Hit { get; init; }
	private readonly Vector3 Offset { get; init; }
	private readonly byte Weapon { get; init; }
	private readonly PlayerBulletHitType HitType { get; init; }
	private readonly ushort HitID { get; init; }

	public readonly override string ToString()
	{
		return $"({Origin}, {Hit}, {Offset}, {Weapon}, {HitType}, {HitID})";
	}
}

