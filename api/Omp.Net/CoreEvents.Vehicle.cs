using Omp.Net.Entities.Player;
using Omp.Net.Entities.Vehicle;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using static Omp.Net.CApi.Events.NativeVehicleEvent;

namespace Omp.Net;

public delegate void VehicleStreamInDelegate(IVehicle vehicle, IPlayer player);
public delegate void VehicleStreamOutDelegate(IVehicle vehicle, IPlayer player);
public delegate void VehicleDeathDelegate(IVehicle vehicle, IPlayer player);
public delegate void PlayerEnterVehicleDelegate(IPlayer player, IVehicle vehicle, bool passenger);
public delegate void PlayerExitVehicleDelegate(IPlayer player, IVehicle vehicle);
public delegate void VehicleDamageStatusUpdateDelegate(IVehicle vehicle, IPlayer player);
public delegate bool VehiclePaintJobDelegate(IPlayer player, IVehicle vehicle, int paintJob);
public delegate bool VehicleModDelegate(IPlayer player, IVehicle vehicle, int component);
public delegate bool VehicleResprayDelegate(IPlayer player, IVehicle vehicle, int color1, int color2);
public delegate void EnterExitModShopDelegate(IPlayer player, bool enterexit, int interiorID);
public delegate void VehicleSpawnDelegate(IVehicle vehicle);
public delegate bool UnoccupiedVehicleUpdateDelegate(IVehicle vehicle, IPlayer player, UnoccupiedVehicleUpdateData data);
public delegate bool TrailerUpdateDelegate(IPlayer player, IVehicle trailer);
public delegate bool VehicleSirenStateChangeDelegate(IPlayer player, IVehicle vehicle, byte sirenState);

public sealed partial class CoreEvents
{
	public event VehicleStreamInDelegate? VehicleStreamIn;
	public event VehicleStreamOutDelegate? VehicleStreamOut;
	public event VehicleDeathDelegate? VehicleDeath;
	public event PlayerEnterVehicleDelegate? PlayerEnterVehicle;
	public event PlayerExitVehicleDelegate? PlayerExitVehicle;
	public event VehicleDamageStatusUpdateDelegate? VehicleDamageStatusUpdate;
	public event VehiclePaintJobDelegate? VehiclePaintJob;
	public event VehicleModDelegate? VehicleMod;
	public event VehicleResprayDelegate? VehicleRespray;
	public event EnterExitModShopDelegate? EnterExitModShop;
	public event VehicleSpawnDelegate? VehicleSpawn;
	public event UnoccupiedVehicleUpdateDelegate? UnoccupiedVehicleUpdate;
	public event TrailerUpdateDelegate? TrailerUpdate;
	public event VehicleSirenStateChangeDelegate? VehicleSirenStateChange;

	private void RegisterVehicleEvents()
	{
		NativeOnVehicleStreamIn += HandleNativeOnVehicleStreamIn;
		NativeOnVehicleStreamOut += HandleNativeOnVehicleStreamOut;
		NativeOnVehicleDeath += HandleNativeOnVehicleDeath;
		NativeOnPlayerEnterVehicle += HandleNativeOnPlayerEnterVehicle;
		NativeOnPlayerExitVehicle += HandleNativeOnPlayerExitVehicle;
		NativeOnVehicleDamageStatusUpdate += HandleNativeOnVehicleDamageStatusUpdate;
		NativeOnVehiclePaintJob += HandleNativeOnVehiclePaintJob;
		NativeOnVehicleMod += HandleNativeOnVehicleMod;
		NativeOnVehicleRespray += HandleNativeOnVehicleRespray;
		NativeOnEnterExitModShop += HandleNativeOnEnterExitModShop;
		NativeOnVehicleSpawn += HandleNativeOnVehicleSpawn;
		NativeOnUnoccupiedVehicleUpdate += HandleNativeOnUnoccupiedVehicleUpdate;
		NativeOnTrailerUpdate += HandleNativeOnTrailerUpdate;
		NativeOnVehicleSirenStateChange += HandleNativeOnVehicleSirenStateChange;
	}

	private void HandleNativeOnVehicleStreamIn(EntityId vehicle, EntityId player)
	{
		VehicleStreamIn?.Invoke(vehiclePool.Get(vehicle.NativeHandle), playerPool.Get(player.NativeHandle));
	}

	private void HandleNativeOnVehicleStreamOut(EntityId vehicle, EntityId player)
	{
		VehicleStreamOut?.Invoke(vehiclePool.Get(vehicle.NativeHandle), playerPool.Get(player.NativeHandle));
	}

	private void HandleNativeOnVehicleDeath(EntityId vehicle, EntityId player)
	{
		VehicleDeath?.Invoke(vehiclePool.Get(vehicle.NativeHandle), playerPool.Get(player.NativeHandle));
	}

	private void HandleNativeOnPlayerEnterVehicle(EntityId player, EntityId vehicle, bool passenger)
	{
		PlayerEnterVehicle?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle), passenger);
	}

	private void HandleNativeOnPlayerExitVehicle(EntityId player, EntityId vehicle)
	{
		PlayerExitVehicle?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle));
	}

	private void HandleNativeOnVehicleDamageStatusUpdate(EntityId vehicle, EntityId player)
	{
		VehicleDamageStatusUpdate?.Invoke(vehiclePool.Get(vehicle.NativeHandle), playerPool.Get(player.NativeHandle));
	}

	private bool HandleNativeOnVehiclePaintJob(EntityId player, EntityId vehicle, int paintJob)
	{
		return VehiclePaintJob?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle), paintJob) ?? true;
	}

	private bool HandleNativeOnVehicleMod(EntityId player, EntityId vehicle, int component)
	{
		return VehicleMod?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle), component) ?? true;
	}

	private bool HandleNativeOnVehicleRespray(EntityId player, EntityId vehicle, int color1, int color2)
	{
		return VehicleRespray?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle), color1, color2) ?? true;
	}

	private void HandleNativeOnEnterExitModShop(EntityId player, bool enterexit, int interiorID)
	{
		EnterExitModShop?.Invoke(playerPool.Get(player.NativeHandle), enterexit, interiorID);
	}

	private void HandleNativeOnVehicleSpawn(EntityId vehicle)
	{
		VehicleSpawn?.Invoke(vehiclePool.Get(vehicle.NativeHandle));
	}

	private bool HandleNativeOnUnoccupiedVehicleUpdate(EntityId vehicle, EntityId player, UnoccupiedVehicleUpdateData data)
	{
		return UnoccupiedVehicleUpdate?.Invoke(vehiclePool.Get(vehicle.NativeHandle), playerPool.Get(player.NativeHandle), data) ?? true;
	}

	private bool HandleNativeOnTrailerUpdate(EntityId player, EntityId vehicle)
	{
		return TrailerUpdate?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle)) ?? true;
	}

	private bool HandleNativeOnVehicleSirenStateChange(EntityId player, EntityId vehicle, byte sirenState)
	{
		return VehicleSirenStateChange?.Invoke(playerPool.Get(player.NativeHandle), vehiclePool.Get(vehicle.NativeHandle), sirenState) ?? true;
	}

}

