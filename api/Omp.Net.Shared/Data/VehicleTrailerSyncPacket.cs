using System.Numerics;
using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VehicleTrailerSyncPacket
{
	public readonly int VehicleID { get; init; }
	public readonly int PlayerID { get; init; }
	public readonly Vector3 Position { get; init; }
	public readonly Vector4 Quat { get; init; }
	public readonly Vector3 Velocity { get; init; }
	public readonly Vector3 TurnVelocity { get; init; }

	public override readonly string ToString()
	{
		return $"({VehicleID}, {PlayerID}, {Position}, {Quat}, {Velocity}, {TurnVelocity})";
	}
};

