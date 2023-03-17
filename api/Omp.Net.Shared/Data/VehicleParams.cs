using System.Runtime.InteropServices;

namespace Omp.Net.Shared.Data;

[StructLayout(LayoutKind.Sequential)]
public readonly record struct VehicleParams
{
	public readonly byte Engine { get; init; }
	public readonly byte Lights { get; init; }
	public readonly byte Alarm { get; init; }
	public readonly byte Doors { get; init; }
	public readonly byte Bonnet { get; init; }
	public readonly byte Boot { get; init; }
	public readonly byte Objective { get; init; }
	public readonly byte Siren { get; init; }
	public readonly byte DoorDriver { get; init; }
	public readonly byte DoorPassenger { get; init; }
	public readonly byte DoorBackLeft { get; init; }
	public readonly byte DoorBackRight { get; init; }
	public readonly byte WindowDriver { get; init; }
	public readonly byte WindowPassenger { get; init; }
	public readonly byte WindowBackLeft { get; init; }
	public readonly byte WindowBackRight { get; init; }

	public override readonly string ToString()
	{
		return $"({Engine}, {Lights}, {Alarm}, {Doors}, {Bonnet}, {Boot}, {Objective}, {Siren}, {DoorDriver}, {DoorBackLeft}, {DoorBackRight}, {WindowDriver}, {WindowPassenger}, {WindowBackLeft}, {WindowBackRight})";
	}
}

