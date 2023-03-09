using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;

namespace Omp.Net.CApi.Events;

internal delegate void OnVehicleStreamInDelegate(EntityId vehicle, EntityId player);
internal delegate void OnVehicleStreamOutDelegate(EntityId vehicle, EntityId player);
internal delegate void OnVehicleDeathDelegate(EntityId vehicle, EntityId player);
internal delegate void OnPlayerEnterVehicleDelegate(EntityId player, EntityId vehicle, bool passenger);
internal delegate void OnPlayerExitVehicleDelegate(EntityId player, EntityId vehicle);
internal delegate void OnVehicleDamageStatusUpdateDelegate(EntityId vehicle, EntityId player);
internal delegate bool OnVehiclePaintJobDelegate(EntityId player, EntityId vehicle, int paintJob);
internal delegate bool OnVehicleModDelegate(EntityId player, EntityId vehicle, int component);
internal delegate bool OnVehicleResprayDelegate(EntityId player, EntityId vehicle, int color1, int color2);
internal delegate void OnEnterExitModShopDelegate(EntityId player, bool enterexit, int interiorID);
internal delegate void OnVehicleSpawnDelegate(EntityId vehicle);
internal delegate bool OnUnoccupiedVehicleUpdateDelegate(EntityId vehicle, EntityId player, UnoccupiedVehicleUpdateData data);
internal delegate bool OnTrailerUpdateDelegate(EntityId player, EntityId trailer);
internal delegate bool OnVehicleSirenStateChangeDelegate(EntityId player, EntityId vehicle, byte sirenState);

internal static class NativeVehicleEvent
{
	public static event OnVehicleStreamInDelegate? NativeOnVehicleStreamIn;
	public static event OnVehicleStreamOutDelegate? NativeOnVehicleStreamOut;
	public static event OnVehicleDeathDelegate? NativeOnVehicleDeath;
	public static event OnPlayerEnterVehicleDelegate? NativeOnPlayerEnterVehicle;
	public static event OnPlayerExitVehicleDelegate? NativeOnPlayerExitVehicle;
	public static event OnVehicleDamageStatusUpdateDelegate? NativeOnVehicleDamageStatusUpdate;
	public static event OnVehiclePaintJobDelegate? NativeOnVehiclePaintJob;
	public static event OnVehicleModDelegate? NativeOnVehicleMod;
	public static event OnVehicleResprayDelegate? NativeOnVehicleRespray;
	public static event OnEnterExitModShopDelegate? NativeOnEnterExitModShop;
	public static event OnVehicleSpawnDelegate? NativeOnVehicleSpawn;
	public static event OnUnoccupiedVehicleUpdateDelegate? NativeOnUnoccupiedVehicleUpdate;
	public static event OnTrailerUpdateDelegate? NativeOnTrailerUpdate;
	public static event OnVehicleSirenStateChangeDelegate? NativeOnVehicleSirenStateChange;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleStreamIn(EntityId vehicle, EntityId player)
	{
		NativeOnVehicleStreamIn?.Invoke(vehicle, player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleStreamOut(EntityId vehicle, EntityId player)
	{
		NativeOnVehicleStreamOut?.Invoke(vehicle, player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleDeath(EntityId vehicle, EntityId player)
	{
		NativeOnVehicleDeath?.Invoke(vehicle, player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerEnterVehicle(EntityId player, EntityId vehicle, bool passenger)
	{
		NativeOnPlayerEnterVehicle?.Invoke(player, vehicle, passenger);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerExitVehicle(EntityId player, EntityId vehicle)
	{
		NativeOnPlayerExitVehicle?.Invoke(player, vehicle);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleDamageStatusUpdate(EntityId vehicle, EntityId player)
	{
		NativeOnVehicleDamageStatusUpdate?.Invoke(vehicle, player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnVehiclePaintJob(EntityId player, EntityId vehicle, int paintJob)
	{
		if (NativeOnVehiclePaintJob is null)
		{
			return 1;
		}
		return NativeOnVehiclePaintJob(player, vehicle, paintJob) ? 1 : 0;
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnVehicleMod(EntityId player, EntityId vehicle, int component)
	{
		if (NativeOnVehicleMod is null)
		{
			return 1;
		}
		return NativeOnVehicleMod(player, vehicle, component) ? 1 : 0;
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnVehicleRespray(EntityId player, EntityId vehicle, int color1, int color2)
	{
		if (NativeOnVehicleRespray is null)
		{
			return 1;
		}
		return NativeOnVehicleRespray(player, vehicle, color1, color2) ? 1 : 0;
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnEnterExitModShop(EntityId player, bool enterexit, int interiorID)
	{
		NativeOnEnterExitModShop?.Invoke(player, enterexit, interiorID);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleSpawn(EntityId vehicle)
	{
		NativeOnVehicleSpawn?.Invoke(vehicle);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnUnoccupiedVehicleUpdate(EntityId vehicle, EntityId player, UnoccupiedVehicleUpdateData data)
	{
		if (NativeOnUnoccupiedVehicleUpdate is null)
		{
			return 1;
		}
		return NativeOnUnoccupiedVehicleUpdate(vehicle, player, data) ? 1 : 0;
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnTrailerUpdate(EntityId player, EntityId trailer)
	{
		if (NativeOnTrailerUpdate is null)
		{
			return 1;
		}
		return NativeOnTrailerUpdate(player, trailer) ? 1 : 0;
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnVehicleSirenStateChange(EntityId player, EntityId vehicle, byte sirenState)
	{
		if (NativeOnVehicleSirenStateChange is null)
		{
			return 1;
		}
		return NativeOnVehicleSirenStateChange(player, vehicle, sirenState) ? 1 : 0;
	}
}
