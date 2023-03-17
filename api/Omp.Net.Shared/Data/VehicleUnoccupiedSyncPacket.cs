using System.Numerics;
using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VehicleUnoccupiedSyncPacket
{
	public readonly int VehicleID { get; init; }
	public readonly int PlayerID { get; init; }
	public readonly byte SeatID { get; init; }
	public readonly Vector3 Roll { get; init; }
	public readonly Vector3 Rotation { get; init; }
	public readonly Vector3 Position { get; init; }
	public readonly Vector3 Velocity { get; init; }
	public readonly Vector3 AngularVelocity { get; init; }
	public readonly float Health { get; init; }

	public override readonly string ToString()
	{
		return $"({VehicleID}, {PlayerID}, {SeatID}, {Roll}, {Rotation}, {Velocity}, {AngularVelocity}, {Health})";
	}
};

