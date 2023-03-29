using Omp.Net.Entities.Player;
using Omp.Net.Shared;
using static Omp.Net.CApi.Events.NativeGangZoneEvent;

namespace Omp.Net;

public delegate void PlayerEnterGangZoneDelegate(IPlayer player, int zoneId);
public delegate void PlayerLeaveGangZoneDelegate(IPlayer player, int zoneId);
public delegate void PlayerClickGangZoneDelegate(IPlayer player, int zoneId);

public sealed partial class CoreEvents
{
	public event PlayerEnterGangZoneDelegate? PlayerEnterGangZone;
	public event PlayerLeaveGangZoneDelegate? PlayerLeaveGangZone;
	public event PlayerClickGangZoneDelegate? PlayerClickGangZone;

	private void RegisterGangZoneEvents()
	{
		NativeOnPlayerEnterGangZone += HandleNativeOnPlayerEnterGangZone;
		NativeOnPlayerLeaveGangZone += HandleNativeOnPlayerLeaveGangZone;
		NativeOnPlayerClickGangZone += HandleNativeOnPlayerClickGangZone;
	}

	private void HandleNativeOnPlayerEnterGangZone(EntityId player, int zoneId)
	{
		PlayerEnterGangZone?.Invoke(playerPool.Get(player.NativeHandle), zoneId);
	}

	private void HandleNativeOnPlayerLeaveGangZone(EntityId player, int zoneId)
	{
		PlayerLeaveGangZone?.Invoke(playerPool.Get(player.NativeHandle), zoneId);
	}

	private void HandleNativeOnPlayerClickGangZone(EntityId player, int zoneId)
	{
		PlayerClickGangZone?.Invoke(playerPool.Get(player.NativeHandle), zoneId);
	}
}
