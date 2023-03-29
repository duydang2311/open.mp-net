using System.Numerics;
using Omp.Net.Entities.Player;
using Omp.Net.Shared.Data;

namespace Omp.Net.Entities.Vehicle;

public interface IVehicle : IEntity
{
	VehicleSpawnData SpawnData { get; set; }
	float Health { get; set; }
	IPlayer Driver { get; }
	IReadOnlyCollection<IPlayer> Passengers { get; }
	string Plate { get; set; }
	int PaintJob { get; set; }
	float ZAngle { get; set; }
	VehicleParams Params { get; set; }
	long RespawnDelay { get; set; }
	int Interior { get; set; }
	IVehicle? Trailer { get; }
	IntPtr Cab { get; }
	IReadOnlyCollection<IVehicle> Carriages { get; }
	Vector3 Velocity { get; set; }
	Vector3 AngularVelocity { get; set; }
	int Model { get; }
	byte LandingGearState { get; }
	long LastOccupiedTime { get; }
	long LastSpawnTime { get; }
	byte SirenState { get; }
	uint HydraThrustAngle { get; }
	float TrainSpeed { get; }
	int LastDriverPoolID { get; }
	(int Primary, int Secondary) Color { get; set; }
	IReadOnlyCollection<IPlayer> StreamedForPlayers { get; }
	(int Panel, int Door, int Light, int Tyre) DamageStatus { get; }

	bool IsDead { get; }
	bool IsRespawning { get; }
	bool IsTrailer { get; }
	bool IsOccupied { get; }
	bool HasBeenOccupied { get; }

	bool IsStreamedInForPlayer(IPlayer player);
	int GetComponentInSlot(int slot);
	void SetDamageStatus(int panelStatus, int doorStatus, byte lightStatus, byte tyreStatus);
	void SetDamageStatus(int panelStatus, int doorStatus, byte lightStatus, byte tyreStatus, IPlayer vehicleUpdater);
	void SetParamsForPlayer(IPlayer player, VehicleParams vehicleParams);
	void SetSiren(bool status);

	void StreamInForPlayer(IPlayer player);
	void StreamOutForPlayer(IPlayer player);
	bool UpdateFromDriverSync(VehicleDriverSyncPacket vehicleSync, IPlayer player);
	bool UpdateFromPassengerSync(VehiclePassengerSyncPacket passengerSync, IPlayer player);
	bool UpdateFromUnoccupied(VehicleUnoccupiedSyncPacket unoccupiedSync, IPlayer player);
	bool UpdateFromTrailerSync(VehicleTrailerSyncPacket unoccupiedSync, IPlayer player);
	void AddComponent(int component);
	void RemoveComponent(int component);
	void PutPlayer(IPlayer player, int seatId);
	void Respawn();
	void AttachTrailer(IVehicle trailer);
	void DetachTrailer();
	void Repair();
	void AddCarriage(IVehicle carriage, int pos);
	void UpdateCarriage(Vector3 pos, Vector3 veloc);
}