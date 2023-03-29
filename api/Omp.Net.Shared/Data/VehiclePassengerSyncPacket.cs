using System.Numerics;
using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VehiclePassengerSyncPacket
{
	public readonly int PlayerID { get; init; }
	public readonly int VehicleID { get; init; }
	public readonly ushort DriveBySeatAdditionalKeyWeapon { get; init; }
	public readonly byte SeatID { get; init; }
	public readonly byte DriveBy { get; init; }
	public readonly byte WeaponID { get; init; }
	public readonly byte AdditionalKey { get; init; }
	public readonly ushort Keys { get; init; }
	public readonly Vector2 HealthArmour { get; init; }
	public readonly ushort LeftRight { get; init; }
	public readonly ushort UpDown { get; init; }
	public readonly Vector3 Position { get; init; }

	public override readonly string ToString()
	{
		return $"({PlayerID}, {VehicleID}, {DriveBySeatAdditionalKeyWeapon}, {SeatID}, {DriveBy}, {WeaponID}, {AdditionalKey}, {Keys}, {HealthArmour}, {LeftRight}, {UpDown}, {Position})";
	}
};
