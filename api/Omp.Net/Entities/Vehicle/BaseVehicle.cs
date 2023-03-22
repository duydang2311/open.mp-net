using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Data;
using static Omp.Net.CApi.Natives.VehicleNative;

namespace Omp.Net.Entities.Vehicle;

public class BaseVehicle : BaseEntity, IVehicle
{
	private readonly IEntityPool<IPlayer> playerPool;
	private readonly IEntityPool<IVehicle> vehiclePool;

	public BaseVehicle(IntPtr nativeHandle, int id) : this(nativeHandle, id, Core.Instance.VehiclePool, Core.Instance.PlayerPool) { }

	private BaseVehicle(IntPtr nativeHandle, int id, IEntityPool<IVehicle> vehiclePool, IEntityPool<IPlayer> playerPool) : base(nativeHandle, id)
	{
		this.vehiclePool = vehiclePool;
		this.playerPool = playerPool;
	}

	public VehicleSpawnData SpawnData
	{
		get => Vehicle_GetSpawnData(NativeHandle);
		set => Vehicle_SetSpawnData(NativeHandle, value);
	}

	public float Health
	{
		get => Vehicle_GetHealth(NativeHandle);
		set => Vehicle_SetHealth(NativeHandle, value);
	}

	public IPlayer Driver => playerPool.Get(Vehicle_GetDriver(NativeHandle));

	public IReadOnlyCollection<IPlayer> Passengers
	{
		get
		{
			var ptr = Marshal.AllocHGlobal(IntPtr.Size);
			var size = Vehicle_GetPassengers(NativeHandle, ptr);
			var arrPtr = Marshal.ReadIntPtr(ptr);
			var players = new IPlayer[size];
			for (var i = 0; i != size; ++i)
			{
				players[i] = playerPool.Get(Marshal.ReadIntPtr(IntPtr.Add(arrPtr, i * IntPtr.Size)));
			}
			Marshal.FreeHGlobal(ptr);
			return players;
		}
	}

	public string Plate
	{
		get => Marshal.PtrToStringAnsi(Vehicle_GetPlate(NativeHandle)) ?? string.Empty;
		set => Vehicle_SetPlate(NativeHandle, value);
	}

	public int PaintJob
	{
		get => Vehicle_GetPaintJob(NativeHandle);
		set => Vehicle_SetPaintJob(NativeHandle, value);
	}

	public float ZAngle
	{
		get => Vehicle_GetZAngle(NativeHandle);
		set => Vehicle_SetZAngle(NativeHandle, value);
	}

	public VehicleParams Params
	{
		get => Vehicle_GetParams(NativeHandle);
		set => Vehicle_SetParams(NativeHandle, value);
	}

	public long RespawnDelay
	{
		get => Vehicle_GetRespawnDelay(NativeHandle);
		set => Vehicle_SetRespawnDelay(NativeHandle, value);
	}

	public int Interior
	{
		get => Vehicle_GetInterior(NativeHandle);
		set => Vehicle_SetInterior(NativeHandle, value);
	}

	public IVehicle? Trailer
	{
		get
		{
			var ptr = Vehicle_GetTrailer(NativeHandle);
			return ptr == IntPtr.Zero
				? default
				: vehiclePool.Get(ptr);
		}
	}

	public IntPtr Cab => Vehicle_GetCab(NativeHandle);

	public IReadOnlyCollection<IVehicle> Carriages
	{
		get
		{
			var ptr = Marshal.AllocHGlobal(IntPtr.Size);
			var size = Vehicle_GetCarriages(NativeHandle, ptr);
			var arrPtr = Marshal.ReadIntPtr(ptr);
			var carriages = new IVehicle[size];
			for (var i = 0; i != size; ++i)
			{
				carriages[i] = vehiclePool.Get(Marshal.ReadIntPtr(IntPtr.Add(arrPtr, i * IntPtr.Size)));
			}
			Marshal.FreeHGlobal(ptr);
			return carriages;
		}
	}

	public Vector3 Velocity
	{
		get => Vehicle_GetVelocity(NativeHandle);
		set => Vehicle_SetVelocity(NativeHandle, value);
	}

	public Vector3 AngularVelocity
	{
		get => Vehicle_GetAngularVelocity(NativeHandle);
		set => Vehicle_SetAngularVelocity(NativeHandle, value);
	}

	public (int Panel, int Door, int Light, int Tyre) DamageStatus
	{
		get
		{
			unsafe
			{
				int panel, door, light, tyre;
				Vehicle_GetDamageStatus(NativeHandle, &panel, &door, &light, &tyre);
				return (panel, door, light, tyre);
			}
		}
	}

	public int Model => Vehicle_GetModel(NativeHandle);

	public byte LandingGearState => Vehicle_GetLandingGearState(NativeHandle);

	public long LastOccupiedTime => Vehicle_GetLastOccupiedTime(NativeHandle);

	public long LastSpawnTime => Vehicle_GetLastSpawnTime(NativeHandle);

	public byte SirenState => Vehicle_GetSirenState(NativeHandle);

	public uint HydraThrustAngle => Vehicle_GetHydraThrustAngle(NativeHandle);

	public float TrainSpeed => Vehicle_GetTrainSpeed(NativeHandle);

	public int LastDriverPoolID => Vehicle_GetLastDriverPoolID(NativeHandle);

	public (int Primary, int Secondary) Color
	{
		get
		{
			unsafe
			{
				int color1, color2;
				Vehicle_GetColour(NativeHandle, &color1, &color2);
				return (color1, color2);
			}
		}
		set => Vehicle_SetColour(NativeHandle, value.Primary, value.Secondary);
	}

	public IReadOnlyCollection<IPlayer> StreamedForPlayers
	{
		get
		{
			var ptr = Marshal.AllocHGlobal(IntPtr.Size);
			var size = Vehicle_StreamedForPlayers(NativeHandle, ptr);
			var arrPtr = Marshal.ReadIntPtr(ptr);
			var players = new IPlayer[size];
			for (var i = 0; i != size; ++i)
			{
				players[i] = playerPool.Get(Marshal.ReadIntPtr(IntPtr.Add(arrPtr, i * IntPtr.Size)));
			}
			Marshal.FreeHGlobal(ptr);
			return players;
		}
	}

	public bool IsDead => Vehicle_IsDead(NativeHandle);

	public bool IsRespawning => Vehicle_IsRespawning(NativeHandle);

	public bool IsTrailer => Vehicle_IsTrailer(NativeHandle);

	public bool IsOccupied => Vehicle_IsOccupied(NativeHandle);

	public bool HasBeenOccupied => Vehicle_HasBeenOccupied(NativeHandle);

	public void AddCarriage(IVehicle carriage, int pos)
	{
		Vehicle_AddCarriage(NativeHandle, carriage.NativeHandle, pos);
	}

	public void AddComponent(int component)
	{
		Vehicle_AddComponent(NativeHandle, component);
	}

	public void AttachTrailer(IVehicle trailer)
	{
		Vehicle_AttachTrailer(NativeHandle, trailer.NativeHandle);
	}

	public void DetachTrailer()
	{
		Vehicle_DetachTrailer(NativeHandle);
	}

	public int GetComponentInSlot(int slot)
	{
		return Vehicle_GetComponentInSlot(NativeHandle, slot);
	}

	public bool IsStreamedInForPlayer(IPlayer player)
	{
		return Vehicle_IsStreamedInForPlayer(NativeHandle, player.NativeHandle);
	}

	public void PutPlayer(IPlayer player, int seatId)
	{
		Vehicle_PutPlayer(NativeHandle, player.NativeHandle, seatId);
	}

	public void RemoveComponent(int component)
	{
		Vehicle_RemoveComponent(NativeHandle, component);
	}

	public void Repair()
	{
		Vehicle_Repair(NativeHandle);
	}

	public void Respawn()
	{
		Vehicle_Respawn(NativeHandle);
	}

	public void SetDamageStatus(int panelStatus, int doorStatus, byte lightStatus, byte tyreStatus)
	{
		Vehicle_SetDamageStatus(NativeHandle, panelStatus, doorStatus, lightStatus, tyreStatus, IntPtr.Zero);
	}

	public void SetDamageStatus(int panelStatus, int doorStatus, byte lightStatus, byte tyreStatus, IPlayer vehicleUpdater)
	{
		Vehicle_SetDamageStatus(NativeHandle, panelStatus, doorStatus, lightStatus, tyreStatus, vehicleUpdater.NativeHandle);
	}

	public void SetParamsForPlayer(IPlayer player, VehicleParams vehicleParams)
	{
		Vehicle_SetParamsForPlayer(NativeHandle, player.NativeHandle, vehicleParams);
	}

	public void SetSiren(bool status)
	{
		Vehicle_SetSiren(NativeHandle, status);
	}

	public void StreamInForPlayer(IPlayer player)
	{
		Vehicle_StreamInForPlayer(NativeHandle, player.NativeHandle);
	}

	public void StreamOutForPlayer(IPlayer player)
	{
		Vehicle_StreamOutForPlayer(NativeHandle, player.NativeHandle);
	}

	public void UpdateCarriage(Vector3 pos, Vector3 veloc)
	{
		Vehicle_UpdateCarriage(NativeHandle, pos, veloc);
	}

	public bool UpdateFromDriverSync(VehicleDriverSyncPacket vehicleSync, IPlayer player)
	{
		return Vehicle_UpdateFromDriverSync(NativeHandle, vehicleSync, player.NativeHandle);
	}

	public bool UpdateFromPassengerSync(VehiclePassengerSyncPacket passengerSync, IPlayer player)
	{
		return Vehicle_UpdateFromPassengerSync(NativeHandle, passengerSync, player.NativeHandle);
	}

	public bool UpdateFromTrailerSync(VehicleTrailerSyncPacket unoccupiedSync, IPlayer player)
	{
		return Vehicle_UpdateFromTrailerSync(NativeHandle, unoccupiedSync, player.NativeHandle);
	}

	public bool UpdateFromUnoccupied(VehicleUnoccupiedSyncPacket unoccupiedSync, IPlayer player)
	{
		return Vehicle_UpdateFromUnoccupied(NativeHandle, unoccupiedSync, player.NativeHandle);
	}
}
