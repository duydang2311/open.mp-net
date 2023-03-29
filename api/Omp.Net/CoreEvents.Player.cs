using System.Numerics;
using Omp.Net.Entities.Player;
using Omp.Net.Entities.Vehicle;
using Omp.Net.Shared;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Events.NativePlayerEvent;

namespace Omp.Net;

public delegate void IncomingConnectionDelegate(IPlayer player, string ipAddress, ushort port);
public delegate void PlayerConnectDelegate(IPlayer player);
public delegate void PlayerDisconnectDelegate(IPlayer player, int reason);
public delegate void PlayerClientInitDelegate(IPlayer player);
public delegate int PlayerRequestSpawnDelegate(IPlayer player);
public delegate void PlayerSpawnDelegate(IPlayer player);
public delegate void PlayerStreamInDelegate(IPlayer player, IPlayer forPlayer);
public delegate void PlayerStreamOutDelegate(IPlayer player, IPlayer forPlayer);
public delegate bool PlayerTextDelegate(IPlayer player, string message);
public delegate bool PlayerCommandTextDelegate(IPlayer player, string message);
public delegate bool PlayerShotMissedDelegate(IPlayer player, PlayerBulletData bulletData);
public delegate bool PlayerShotPlayerDelegate(IPlayer player, IPlayer target, PlayerBulletData bulletData);
public delegate bool PlayerShotVehicleDelegate(IPlayer player, IVehicle target, PlayerBulletData bulletData);
public delegate bool PlayerShotObjectDelegate(IPlayer player, EntityId target, PlayerBulletData bulletData);
public delegate bool PlayerShotPlayerObjectDelegate(IPlayer player, EntityId target, PlayerBulletData bulletData);
public delegate void PlayerScoreChangeDelegate(IPlayer player, int score);
public delegate void PlayerNameChangeDelegate(IPlayer player, string oldName);
public delegate void PlayerInteriorChangeDelegate(IPlayer player, uint newInterior, uint oldInterior);
public delegate void PlayerStateChangeDelegate(IPlayer player, PlayerState newState, PlayerState oldState);
public delegate void PlayerKeyStateChangeDelegate(IPlayer player, uint newKeys, uint oldKeys);
public delegate void PlayerDeathDelegate(IPlayer player, IPlayer killer, int reason);
public delegate void PlayerTakeDamageDelegate(IPlayer player, IPlayer from, float amount, uint weapon, BodyPart part);
public delegate void PlayerGiveDamageDelegate(IPlayer player, IPlayer to, float amount, uint weapon, BodyPart part);
public delegate void PlayerClickMapDelegate(IPlayer player, Vector3 pos);
public delegate void PlayerClickPlayerDelegate(IPlayer player, IPlayer clicked, PlayerClickSource source);
public delegate void ClientCheckResponseDelegate(IPlayer player, int actionType, int address, int results);
public delegate bool PlayerUpdateDelegate(IPlayer player, long now);

public sealed partial class CoreEvents
{
	public event IncomingConnectionDelegate? IncomingConnection;
	public event PlayerConnectDelegate? PlayerConnect;
	public event PlayerDisconnectDelegate? PlayerDisconnect;
	public event PlayerClientInitDelegate? PlayerClientInit;
	public event PlayerRequestSpawnDelegate? PlayerRequestSpawn;
	public event PlayerSpawnDelegate? PlayerSpawn;
	public event PlayerStreamInDelegate? PlayerStreamIn;
	public event PlayerStreamOutDelegate? PlayerStreamOut;
	public event PlayerTextDelegate? PlayerText;
	public event PlayerCommandTextDelegate? PlayerCommandText;
	public event PlayerShotMissedDelegate? PlayerShotMissed;
	public event PlayerShotPlayerDelegate? PlayerShotPlayer;
	public event PlayerShotVehicleDelegate? PlayerShotVehicle;
	public event PlayerShotObjectDelegate? PlayerShotObject;
	public event PlayerShotPlayerObjectDelegate? PlayerShotPlayerObject;
	public event PlayerScoreChangeDelegate? PlayerScoreChange;
	public event PlayerNameChangeDelegate? PlayerNameChange;
	public event PlayerInteriorChangeDelegate? PlayerInteriorChange;
	public event PlayerStateChangeDelegate? PlayerStateChange;
	public event PlayerKeyStateChangeDelegate? PlayerKeyStateChange;
	public event PlayerDeathDelegate? PlayerDeath;
	public event PlayerTakeDamageDelegate? PlayerTakeDamage;
	public event PlayerGiveDamageDelegate? PlayerGiveDamage;
	public event PlayerClickMapDelegate? PlayerClickMap;
	public event PlayerClickPlayerDelegate? PlayerClickPlayer;
	public event ClientCheckResponseDelegate? ClientCheckResponse;
	public event PlayerUpdateDelegate? PlayerUpdate;

	private void RegisterPlayerEvents()
	{
		NativeOnIncomingConnection += HandleNativeOnIncomingConnection;
		NativeOnPlayerConnect += HandleNativeOnPlayerConnect;
		NativeOnPlayerDisconnect += HandleNativeOnPlayerDisconnect;
		NativeOnPlayerClientInit += HandleNativeOnPlayerClientInit;
		NativeOnPlayerRequestSpawn += HandleNativeOnPlayerRequestSpawn;
		NativeOnPlayerSpawn += HandleNativeOnPlayerSpawn;
		NativeOnPlayerStreamIn += HandleNativeOnPlayerStreamIn;
		NativeOnPlayerStreamOut += HandleNativeOnPlayerStreamOut;
		NativeOnPlayerScoreChange += HandleNativeOnPlayerScoreChange;
		NativeOnPlayerNameChange += HandleNativeOnPlayerNameChange;
		NativeOnPlayerInteriorChange += HandleNativeOnPlayerInteriorChange;
		NativeOnPlayerStateChange += HandleNativeOnPlayerStateChange;
		NativeOnPlayerKeyStateChange += HandleNativeOnPlayerKeyStateChange;
		NativeOnPlayerDeath += HandleNativeOnPlayerDeath;
		NativeOnPlayerTakeDamage += HandleNativeOnPlayerTakeDamage;
		NativeOnPlayerGiveDamage += HandleNativeOnPlayerGiveDamage;
		NativeOnPlayerClickMap += HandleNativeOnPlayerClickMap;
		NativeOnPlayerClickPlayer += HandleNativeOnPlayerClickPlayer;
		NativeOnClientCheckResponse += HandleNativeOnClientCheckResponse;
		NativeOnPlayerText += HandleNativeOnPlayerText;
		NativeOnPlayerCommandText += HandleNativeOnPlayerCommandText;
		NativeOnPlayerShotMissed += HandleNativeOnPlayerShotMissed;
		NativeOnPlayerShotPlayer += HandleNativeOnPlayerShotPlayer;
		NativeOnPlayerShotVehicle += HandleNativeOnPlayerShotVehicle;
		NativeOnPlayerShotObject += HandleNativeOnPlayerShotObject;
		NativeOnPlayerShotPlayerObject += HandleNativeOnPlayerShotPlayerObject;
		NativeOnPlayerUpdate += HandleNativeOnPlayerUpdate;
	}

	private void HandleNativeOnIncomingConnection(EntityId player, string ipAddress, ushort port)
	{
		IncomingConnection?.Invoke(playerPool.Get(player.NativeHandle, player.Id), ipAddress, port);
	}

	private void HandleNativeOnPlayerConnect(EntityId player)
	{
		PlayerConnect?.Invoke(playerPool.Get(player.NativeHandle, player.Id));
	}

	private void HandleNativeOnPlayerDisconnect(EntityId player, int reason)
	{
		PlayerDisconnect?.Invoke(playerPool.Get(player.NativeHandle, player.Id), reason);
	}

	private void HandleNativeOnPlayerClientInit(EntityId player)
	{
		PlayerClientInit?.Invoke(playerPool.Get(player.NativeHandle, player.Id));
	}

	private int HandleNativeOnPlayerRequestSpawn(EntityId player)
	{
		return PlayerRequestSpawn?.Invoke(playerPool.Get(player.NativeHandle, player.Id)) ?? default;
	}

	private void HandleNativeOnPlayerSpawn(EntityId player)
	{
		PlayerSpawn?.Invoke(playerPool.Get(player.NativeHandle, player.Id));
	}

	private void HandleNativeOnPlayerStreamIn(EntityId player, EntityId forPlayer)
	{
		PlayerStreamIn?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(forPlayer.NativeHandle, forPlayer.Id));
	}

	private void HandleNativeOnPlayerStreamOut(EntityId player, EntityId forPlayer)
	{
		PlayerStreamOut?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(forPlayer.NativeHandle, forPlayer.Id));
	}

	private bool HandleNativeOnPlayerText(EntityId player, string message)
	{
		return PlayerText?.Invoke(playerPool.Get(player.NativeHandle, player.Id), message) ?? default;
	}

	private bool HandleNativeOnPlayerCommandText(EntityId player, string message)
	{
		return PlayerCommandText?.Invoke(playerPool.Get(player.NativeHandle, player.Id), message) ?? default;
	}

	private bool HandleNativeOnPlayerShotMissed(EntityId player, PlayerBulletData bulletData)
	{
		return PlayerShotMissed?.Invoke(playerPool.Get(player.NativeHandle, player.Id), bulletData) ?? default;
	}

	private bool HandleNativeOnPlayerShotPlayer(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		return PlayerShotPlayer?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(target.NativeHandle, target.Id), bulletData) ?? default;
	}

	private bool HandleNativeOnPlayerShotVehicle(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		return PlayerShotVehicle?.Invoke(playerPool.Get(player.NativeHandle, player.Id), core.VehiclePool.Get(target.NativeHandle, target.Id), bulletData) ?? default;
	}

	private bool HandleNativeOnPlayerShotObject(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		return PlayerShotObject?.Invoke(playerPool.Get(player.NativeHandle, player.Id), target, bulletData) ?? default;
	}

	private bool HandleNativeOnPlayerShotPlayerObject(EntityId player, EntityId target, PlayerBulletData bulletData)
	{
		return PlayerShotPlayerObject?.Invoke(playerPool.Get(player.NativeHandle, player.Id), target, bulletData) ?? default;
	}

	private void HandleNativeOnPlayerScoreChange(EntityId player, int score)
	{
		PlayerScoreChange?.Invoke(playerPool.Get(player.NativeHandle, player.Id), score);
	}

	private void HandleNativeOnPlayerNameChange(EntityId player, string oldName)
	{
		PlayerNameChange?.Invoke(playerPool.Get(player.NativeHandle, player.Id), oldName);
	}

	private void HandleNativeOnPlayerInteriorChange(EntityId player, uint newInterior, uint oldInterior)
	{
		PlayerInteriorChange?.Invoke(playerPool.Get(player.NativeHandle, player.Id), newInterior, oldInterior);
	}

	private void HandleNativeOnPlayerStateChange(EntityId player, PlayerState newState, PlayerState oldState)
	{
		PlayerStateChange?.Invoke(playerPool.Get(player.NativeHandle, player.Id), newState, oldState);
	}

	private void HandleNativeOnPlayerKeyStateChange(EntityId player, uint newKeys, uint oldKeys)
	{
		PlayerKeyStateChange?.Invoke(playerPool.Get(player.NativeHandle, player.Id), newKeys, oldKeys);
	}

	private void HandleNativeOnPlayerDeath(EntityId player, EntityId killer, int reason)
	{
		PlayerDeath?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(killer.NativeHandle, killer.Id), reason);
	}

	private void HandleNativeOnPlayerTakeDamage(EntityId player, EntityId from, float amount, uint weapon, BodyPart part)
	{
		PlayerTakeDamage?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(from.NativeHandle, from.Id), amount, weapon, part);
	}

	private void HandleNativeOnPlayerGiveDamage(EntityId player, EntityId to, float amount, uint weapon, BodyPart part)
	{
		PlayerGiveDamage?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(to.NativeHandle, to.Id), amount, weapon, part);
	}

	private void HandleNativeOnPlayerClickMap(EntityId player, Vector3 pos)
	{
		PlayerClickMap?.Invoke(playerPool.Get(player.NativeHandle, player.Id), pos);
	}

	private void HandleNativeOnPlayerClickPlayer(EntityId player, EntityId clicked, PlayerClickSource source)
	{
		PlayerClickPlayer?.Invoke(playerPool.Get(player.NativeHandle, player.Id), playerPool.Get(clicked.NativeHandle, clicked.Id), source);
	}

	private void HandleNativeOnClientCheckResponse(EntityId player, int actionType, int address, int results)
	{
		ClientCheckResponse?.Invoke(playerPool.Get(player.NativeHandle, player.Id), actionType, address, results);
	}

	private bool HandleNativeOnPlayerUpdate(EntityId player, long now)
	{
		return PlayerUpdate?.Invoke(playerPool.Get(player.NativeHandle, player.Id), now) ?? default;
	}
}

