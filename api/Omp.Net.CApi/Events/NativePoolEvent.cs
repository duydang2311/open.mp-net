using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;

namespace Omp.Net.CApi.Events;

internal delegate void OnActorCreatedDelegate(EntityId actor);
internal delegate void OnActorDestroyedDelegate(EntityId actor);
internal delegate void OnPickupCreatedDelegate(EntityId pickup);
internal delegate void OnPickupDestroyedDelegate(EntityId pickup);
internal delegate void OnPlayerCreatedDelegate(EntityId player);
internal delegate void OnPlayerDestroyedDelegate(EntityId player);
internal delegate void OnVehicleCreatedDelegate(EntityId vehicle);
internal delegate void OnVehicleDestroyedDelegate(EntityId vehicle);
internal delegate void OnObjectCreatedDelegate(EntityId obj);
internal delegate void OnObjectDestroyedDelegate(EntityId obj);
internal delegate void OnPlayerObjectCreatedDelegate(EntityId playerObject);
internal delegate void OnPlayerObjectDestroyedDelegate(EntityId playerObject);
internal delegate void OnTextLabelCreatedDelegate(EntityId textLabel);
internal delegate void OnTextLabelDestroyedDelegate(EntityId textLabel);
internal delegate void OnPlayerTextLabelCreatedDelegate(EntityId playerTextLabel);
internal delegate void OnPlayerTextLabelDestroyedDelegate(EntityId playerTextLabel);
internal delegate void OnClassCreatedDelegate(int id);
internal delegate void OnClassDestroyedDelegate(int id);
internal delegate void OnGangZoneCreatedDelegate(int id);
internal delegate void OnGangZoneDestroyedDelegate(int id);
internal delegate void OnMenuCreatedDelegate(int id);
internal delegate void OnMenuDestroyedDelegate(int id);
internal delegate void OnTextDrawCreatedDelegate(int id);
internal delegate void OnTextDrawDestroyedDelegate(int id);

internal static class NativePoolEvent
{
	public static event OnActorCreatedDelegate? NativeOnActorCreated;
	public static event OnActorDestroyedDelegate? NativeOnActorDestroyed;
	public static event OnPickupCreatedDelegate? NativeOnPickupCreated;
	public static event OnPickupDestroyedDelegate? NativeOnPickupDestroyed;
	public static event OnPlayerCreatedDelegate? NativeOnPlayerCreated;
	public static event OnPlayerDestroyedDelegate? NativeOnPlayerDestroyed;
	public static event OnVehicleCreatedDelegate? NativeOnVehicleCreated;
	public static event OnVehicleDestroyedDelegate? NativeOnVehicleDestroyed;
	public static event OnObjectCreatedDelegate? NativeOnObjectCreated;
	public static event OnObjectDestroyedDelegate? NativeOnObjectDestroyed;
	public static event OnPlayerObjectCreatedDelegate? NativeOnPlayerObjectCreated;
	public static event OnPlayerObjectDestroyedDelegate? NativeOnPlayerObjectDestroyed;
	public static event OnTextLabelCreatedDelegate? NativeOnTextLabelCreated;
	public static event OnTextLabelDestroyedDelegate? NativeOnTextLabelDestroyed;
	public static event OnPlayerTextLabelCreatedDelegate? NativeOnPlayerTextLabelCreated;
	public static event OnPlayerTextLabelDestroyedDelegate? NativeOnPlayerTextLabelDestroyed;
	public static event OnClassCreatedDelegate? NativeOnClassCreated;
	public static event OnClassDestroyedDelegate? NativeOnClassDestroyed;
	public static event OnGangZoneCreatedDelegate? NativeOnGangZoneCreated;
	public static event OnGangZoneDestroyedDelegate? NativeOnGangZoneDestroyed;
	public static event OnMenuCreatedDelegate? NativeOnMenuCreated;
	public static event OnMenuDestroyedDelegate? NativeOnMenuDestroyed;
	public static event OnTextDrawCreatedDelegate? NativeOnTextDrawCreated;
	public static event OnTextDrawDestroyedDelegate? NativeOnTextDrawDestroyed;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnActorCreated(EntityId actor)
	{
		NativeOnActorCreated?.Invoke(actor);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnActorDestroyed(EntityId actor)
	{
		NativeOnActorDestroyed?.Invoke(actor);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPickupCreated(EntityId pickup)
	{
		NativeOnPickupCreated?.Invoke(pickup);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPickupDestroyed(EntityId pickup)
	{
		NativeOnPickupDestroyed?.Invoke(pickup);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerCreated(EntityId player)
	{
		NativeOnPlayerCreated?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerDestroyed(EntityId player)
	{
		NativeOnPlayerDestroyed?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleCreated(EntityId vehicle)
	{
		NativeOnVehicleCreated?.Invoke(vehicle);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnVehicleDestroyed(EntityId vehicle)
	{
		NativeOnVehicleDestroyed?.Invoke(vehicle);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnObjectCreated(EntityId obj)
	{
		NativeOnObjectCreated?.Invoke(obj);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnObjectDestroyed(EntityId obj)
	{
		NativeOnObjectDestroyed?.Invoke(obj);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerObjectCreated(EntityId playerObject)
	{
		NativeOnPlayerObjectCreated?.Invoke(playerObject);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerObjectDestroyed(EntityId playerObject)
	{
		NativeOnPlayerObjectDestroyed?.Invoke(playerObject);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnTextLabelCreated(EntityId textLabel)
	{
		NativeOnTextLabelCreated?.Invoke(textLabel);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnTextLabelDestroyed(EntityId textLabel)
	{
		NativeOnTextLabelDestroyed?.Invoke(textLabel);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerTextLabelCreated(EntityId playerTextLabel)
	{
		NativeOnPlayerTextLabelCreated?.Invoke(playerTextLabel);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerTextLabelDestroyed(EntityId playerTextLabel)
	{
		NativeOnPlayerTextLabelDestroyed?.Invoke(playerTextLabel);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnClassCreated(int id)
	{
		NativeOnClassCreated?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnClassDestroyed(int id)
	{
		NativeOnClassDestroyed?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnGangZoneCreated(int id)
	{
		NativeOnGangZoneCreated?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnGangZoneDestroyed(int id)
	{
		NativeOnGangZoneDestroyed?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnMenuCreated(int id)
	{
		NativeOnMenuCreated?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnMenuDestroyed(int id)
	{
		NativeOnMenuDestroyed?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnTextDrawCreated(int id)
	{
		NativeOnTextDrawCreated?.Invoke(id);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnTextDrawDestroyed(int id)
	{
		NativeOnTextDrawDestroyed?.Invoke(id);
	}
}
