using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Events;

internal delegate void OnIncomingConnectionDelegate(EntityId player, string ipAddress, ushort port);
internal delegate void OnPlayerConnectDelegate(EntityId player);
internal delegate void OnPlayerDisconnectDelegate(EntityId player, int reason);
internal delegate void OnPlayerClientInitDelegate(EntityId player);
internal delegate int OnPlayerRequestSpawnDelegate(EntityId player);
internal delegate void OnPlayerSpawnDelegate(EntityId player);
internal delegate void OnPlayerStreamInDelegate(EntityId player, EntityId forPlayer);
internal delegate void OnPlayerStreamOutDelegate(EntityId player, EntityId forPlayer);
internal delegate bool OnPlayerTextDelegate(EntityId player, string message);
internal delegate bool OnPlayerCommandTextDelegate(EntityId player, string message);
internal delegate bool OnPlayerShotMissedDelegate(EntityId player, PlayerBulletData bulletData);
internal delegate bool OnPlayerShotPlayerDelegate(EntityId player, EntityId target, PlayerBulletData bulletData);
internal delegate bool OnPlayerShotVehicleDelegate(EntityId player, EntityId target, PlayerBulletData bulletData);
internal delegate bool OnPlayerShotObjectDelegate(EntityId player, EntityId target, PlayerBulletData bulletData);
internal delegate bool OnPlayerShotPlayerObjectDelegate(EntityId player, EntityId target, PlayerBulletData bulletData);
internal delegate void OnPlayerScoreChangeDelegate(EntityId player, int score);
internal delegate void OnPlayerNameChangeDelegate(EntityId player, string oldName);
internal delegate void OnPlayerInteriorChangeDelegate(EntityId player, uint newInterior, uint oldInterior);
internal delegate void OnPlayerStateChangeDelegate(EntityId player, PlayerState newState, PlayerState oldState);
internal delegate void OnPlayerKeyStateChangeDelegate(EntityId player, uint newKeys, uint oldKeys);
internal delegate void OnPlayerDeathDelegate(EntityId player, EntityId killer, int reason);
internal delegate void OnPlayerTakeDamageDelegate(EntityId player, EntityId from, float amount, uint weapon, BodyPart part);
internal delegate void OnPlayerGiveDamageDelegate(EntityId player, EntityId to, float amount, uint weapon, BodyPart part);
internal delegate void OnPlayerClickMapDelegate(EntityId player, Vector3 pos);
internal delegate void OnPlayerClickPlayerDelegate(EntityId player, EntityId clicked, PlayerClickSource source);
internal delegate void OnClientCheckResponseDelegate(EntityId player, int actionType, int address, int results);
internal delegate bool OnPlayerUpdateDelegate(EntityId player, long now);

internal static partial class NativePlayerEvent
{
	public static event OnIncomingConnectionDelegate? NativeOnIncomingConnection;
	public static event OnPlayerConnectDelegate? NativeOnPlayerConnect;
	public static event OnPlayerDisconnectDelegate? NativeOnPlayerDisconnect;
	public static event OnPlayerClientInitDelegate? NativeOnPlayerClientInit;
	public static event OnPlayerRequestSpawnDelegate? NativeOnPlayerRequestSpawn;
	public static event OnPlayerSpawnDelegate? NativeOnPlayerSpawn;
	public static event OnPlayerStreamInDelegate? NativeOnPlayerStreamIn;
	public static event OnPlayerStreamOutDelegate? NativeOnPlayerStreamOut;
	public static event OnPlayerTextDelegate? NativeOnPlayerText;
	public static event OnPlayerCommandTextDelegate? NativeOnPlayerCommandText;
	public static event OnPlayerShotMissedDelegate? NativeOnPlayerShotMissed;
	public static event OnPlayerShotPlayerDelegate? NativeOnPlayerShotPlayer;
	public static event OnPlayerShotVehicleDelegate? NativeOnPlayerShotVehicle;
	public static event OnPlayerShotObjectDelegate? NativeOnPlayerShotObject;
	public static event OnPlayerShotPlayerObjectDelegate? NativeOnPlayerShotPlayerObject;
	public static event OnPlayerScoreChangeDelegate? NativeOnPlayerScoreChange;
	public static event OnPlayerNameChangeDelegate? NativeOnPlayerNameChange;
	public static event OnPlayerInteriorChangeDelegate? NativeOnPlayerInteriorChange;
	public static event OnPlayerStateChangeDelegate? NativeOnPlayerStateChange;
	public static event OnPlayerKeyStateChangeDelegate? NativeOnPlayerKeyStateChange;
	public static event OnPlayerDeathDelegate? NativeOnPlayerDeath;
	public static event OnPlayerTakeDamageDelegate? NativeOnPlayerTakeDamage;
	public static event OnPlayerGiveDamageDelegate? NativeOnPlayerGiveDamage;
	public static event OnPlayerClickMapDelegate? NativeOnPlayerClickMap;
	public static event OnPlayerClickPlayerDelegate? NativeOnPlayerClickPlayer;
	public static event OnClientCheckResponseDelegate? NativeOnClientCheckResponse;
	public static event OnPlayerUpdateDelegate? NativeOnPlayerUpdate;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnIncomingConnection(EntityId player, IntPtr ipAddress, ushort port)
	{
		NativeOnIncomingConnection?.Invoke(player, Marshal.PtrToStringAnsi(ipAddress)!, port);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerConnect(EntityId player)
	{
		NativeOnPlayerConnect?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerDisconnect(EntityId player, int reason)
	{
		NativeOnPlayerDisconnect?.Invoke(player, reason);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerClientInit(EntityId player)
	{
		NativeOnPlayerClientInit?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerRequestSpawn(EntityId player)
	{
		if (NativeOnPlayerRequestSpawn is null)
		{
			return 1;
		}
		return NativeOnPlayerRequestSpawn.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerSpawn(EntityId player)
	{
		NativeOnPlayerSpawn?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerStreamIn(EntityId player, EntityId forPlayer)
	{
		NativeOnPlayerStreamIn?.Invoke(player, forPlayer);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerStreamOut(EntityId player, EntityId forPlayer)
	{
		NativeOnPlayerStreamOut?.Invoke(player, forPlayer);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerText(EntityId player, IntPtr message)
	{
		if (NativeOnPlayerText is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerText(player, Marshal.PtrToStringAnsi(message) ?? string.Empty);
		return Unsafe.As<bool, int>(ref ret);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerCommandText(EntityId player, IntPtr message)
	{
		if (NativeOnPlayerCommandText is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerCommandText(player, Marshal.PtrToStringAnsi(message) ?? string.Empty);
		return Unsafe.As<bool, int>(ref ret);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerShotMissed(EntityId player, PlayerBulletData bulletData)
	{
		if (NativeOnPlayerShotMissed is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerShotMissed(player, bulletData);
		return Unsafe.As<bool, int>(ref ret);
	}
	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerShotPlayer(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		if (NativeOnPlayerShotPlayer is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerShotPlayer(player, target, bulletData);
		return Unsafe.As<bool, int>(ref ret);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerShotVehicle(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		if (NativeOnPlayerShotVehicle is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerShotVehicle(player, target, bulletData);
		return Unsafe.As<bool, int>(ref ret);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerShotObject(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		if (NativeOnPlayerShotObject is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerShotObject(player, target, bulletData);
		return Unsafe.As<bool, int>(ref ret);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerShotPlayerObject(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		if (NativeOnPlayerShotPlayerObject is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerShotPlayerObject(player, target, bulletData);
		return Unsafe.As<bool, int>(ref ret);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerScoreChange(EntityId player, int score)
	{
		NativeOnPlayerScoreChange?.Invoke(player, score);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerNameChange(EntityId player, IntPtr oldName)
	{
		NativeOnPlayerNameChange?.Invoke(player, Marshal.PtrToStringAnsi(oldName) ?? string.Empty);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerInteriorChange(EntityId player, uint newInterior, uint oldInterior)
	{
		NativeOnPlayerInteriorChange?.Invoke(player, newInterior, oldInterior);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerStateChange(EntityId player, PlayerState newState, PlayerState oldState)
	{
		NativeOnPlayerStateChange?.Invoke(player, newState, oldState);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerKeyStateChange(EntityId player, uint newKeys, uint oldKeys)
	{
		NativeOnPlayerKeyStateChange?.Invoke(player, newKeys, oldKeys);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerDeath(EntityId player, EntityId killer, int reason)
	{
		NativeOnPlayerDeath?.Invoke(player, killer, reason);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerTakeDamage(EntityId player, EntityId from, float amount, uint weapon, BodyPart part)
	{
		NativeOnPlayerTakeDamage?.Invoke(player, from, amount, weapon, part);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerGiveDamage(EntityId player, EntityId to, float amount, uint weapon, BodyPart part)
	{
		NativeOnPlayerGiveDamage?.Invoke(player, to, amount, weapon, part);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerClickMap(EntityId player, Vector3 pos)
	{
		NativeOnPlayerClickMap?.Invoke(player, pos);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerClickPlayer(EntityId player, EntityId clicked, PlayerClickSource source)
	{
		NativeOnPlayerClickPlayer?.Invoke(player, clicked, source);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnClientCheckResponse(EntityId player, int actionType, int address, int results)
	{
		NativeOnClientCheckResponse?.Invoke(player, actionType, address, results);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerUpdate(EntityId player, long now)
	{
		if (NativeOnPlayerUpdate is null)
		{
			return 1;
		}
		var ret = NativeOnPlayerUpdate(player, now);
		return Unsafe.As<bool, int>(ref ret);
	}
}
