using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Data;

namespace Omp.Net.CApi.Natives;

internal static class VehicleNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetSpawnData(IntPtr vehicle, VehicleSpawnData data);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern VehicleSpawnData Vehicle_GetSpawnData(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_IsStreamedInForPlayer(IntPtr vehicle, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_StreamInForPlayer(IntPtr vehicle, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_StreamOutForPlayer(IntPtr vehicle, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetColour(IntPtr vehicle, int col1, int col2);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern unsafe void Vehicle_GetColour(IntPtr vehicle, int* primaryColor, int* secondaryColor);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetHealth(IntPtr vehicle, float health);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Vehicle_GetHealth(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_UpdateFromDriverSync(IntPtr vehicle, VehicleDriverSyncPacket vehicleSync, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_UpdateFromPassengerSync(IntPtr vehicle, VehiclePassengerSyncPacket passengerSync, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_UpdateFromUnoccupied(IntPtr vehicle, VehicleUnoccupiedSyncPacket unoccupiedSync, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_UpdateFromTrailerSync(IntPtr vehicle, VehicleTrailerSyncPacket unoccupiedSync, IntPtr player);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_StreamedForPlayers(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_GetDriver(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_GetPassengers(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion, CharSet = CharSet.Ansi)]
	public static extern void Vehicle_SetPlate(IntPtr vehicle, string plate);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_GetPlate(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetDamageStatus(IntPtr vehicle, int panelStatus, int doorStatus, byte lightStatus, byte tyreStatus, IntPtr vehicleUpdater);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern unsafe void Vehicle_GetDamageStatus(IntPtr vehicle, int* panelStatus, int* doorStatus, int* lightStatus, int* tyreStatus);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetPaintJob(IntPtr vehicle, int paintjob);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Vehicle_GetPaintJob(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_AddComponent(IntPtr vehicle, int component);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Vehicle_GetComponentInSlot(IntPtr vehicle, int slot);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_RemoveComponent(IntPtr vehicle, int component);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_PutPlayer(IntPtr vehicle, IntPtr player, int seatId);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetZAngle(IntPtr vehicle, float angle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Vehicle_GetZAngle(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetParams(IntPtr vehicle, VehicleParams vehicleParams);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetParamsForPlayer(IntPtr vehicle, IntPtr player, VehicleParams vehicleParams);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern VehicleParams Vehicle_GetParams(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_IsDead(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_Respawn(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern long Vehicle_GetRespawnDelay(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetRespawnDelay(IntPtr vehicle, long seconds);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_IsRespawning(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetInterior(IntPtr vehicle, int interior);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Vehicle_GetInterior(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_AttachTrailer(IntPtr vehicle, IntPtr trailer);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_DetachTrailer(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_IsTrailer(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_GetTrailer(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_GetCab(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_Repair(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_AddCarriage(IntPtr vehicle, IntPtr carriage, int pos);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_UpdateCarriage(IntPtr vehicle, Vector3 pos, Vector3 veloc);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr Vehicle_GetCarriages(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetVelocity(IntPtr vehicle, Vector3 velocity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Vehicle_GetVelocity(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetAngularVelocity(IntPtr vehicle, Vector3 velocity);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 Vehicle_GetAngularVelocity(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Vehicle_GetModel(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern byte Vehicle_GetLandingGearState(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_HasBeenOccupied(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern long Vehicle_GetLastOccupiedTime(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern long Vehicle_GetLastSpawnTime(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Vehicle_IsOccupied(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Vehicle_SetSiren(IntPtr vehicle, bool status);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern byte Vehicle_GetSirenState(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint Vehicle_GetHydraThrustAngle(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float Vehicle_GetTrainSpeed(IntPtr vehicle);

	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int Vehicle_GetLastDriverPoolID(IntPtr vehicle);
}
