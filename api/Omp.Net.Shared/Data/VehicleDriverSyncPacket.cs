using System.Numerics;
using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VehicleDriverSyncPacket
{
	public readonly int PlayerID { get; init; }
	public readonly ushort VehicleID { get; init; }
	public readonly ushort LeftRight { get; init; }
	public readonly ushort UpDown { get; init; }
	public readonly ushort Keys { get; init; }
	public readonly Vector3 Rotation { get; init; }
	public readonly Vector3 Position { get; init; }
	public readonly Vector3 Velocity { get; init; }
	public readonly float Health { get; init; }
	public readonly Vector2 PlayerHealthArmour { get; init; }
	public readonly byte Siren { get; init; }
	public readonly byte LandingGear { get; init; }
	public readonly ushort TrailerID { get; init; }
	public readonly bool HasTrailer { get; init; }
	public readonly byte AdditionalKeyWeapon { get; init; }
	public readonly byte WeaponID { get; init; }
	public readonly byte AdditionalKey { get; init; }
	public readonly uint HydraThrustAngle { get; init; }
	public readonly float TrainSpeed { get; init; }

	public override readonly string ToString()
	{
		return $"({PlayerID}, {VehicleID}, {LeftRight}, {UpDown}, {Keys}, {Rotation}, {Position}, {Velocity}, {Health}, {PlayerHealthArmour}, {Siren}, {LandingGear}, {TrailerID}, {HasTrailer}, {AdditionalKeyWeapon}, {WeaponID}, {AdditionalKey}, {HydraThrustAngle}, {TrainSpeed})";
	}
};
