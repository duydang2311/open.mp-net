using Omp.Net.Entities.Player;
using Omp.Net.Shared;
using static Omp.Net.CApi.Events.NativeCheckpointEvent;

namespace Omp.Net;

public delegate void PlayerEnterCheckpointDelegate(IPlayer player);
public delegate void PlayerLeaveCheckpointDelegate(IPlayer player);
public delegate void PlayerEnterRaceCheckpointDelegate(IPlayer player);
public delegate void PlayerLeaveRaceCheckpointDelegate(IPlayer player);

public sealed partial class CoreEvents
{
	public event PlayerEnterCheckpointDelegate? PlayerEnterCheckpoint;
	public event PlayerLeaveCheckpointDelegate? PlayerLeaveCheckpoint;
	public event PlayerEnterRaceCheckpointDelegate? PlayerEnterRaceCheckpoint;
	public event PlayerLeaveRaceCheckpointDelegate? PlayerLeaveRaceCheckpoint;

	private void RegisterCheckpointEvents()
	{
		NativeOnPlayerEnterCheckpoint += HandleNativeOnPlayerEnterCheckpoint;
		NativeOnPlayerLeaveCheckpoint += HandleNativeOnPlayerLeaveCheckpoint;
		NativeOnPlayerEnterRaceCheckpoint += HandleNativeOnPlayerEnterRaceCheckpoint;
		NativeOnPlayerLeaveRaceCheckpoint += HandleNativeOnPlayerLeaveRaceCheckpoint;
	}

	private void HandleNativeOnPlayerEnterCheckpoint(EntityId player)
	{
		PlayerEnterCheckpoint?.Invoke(playerPool.Get(player.NativeHandle));
	}

	private void HandleNativeOnPlayerLeaveCheckpoint(EntityId player)
	{
		PlayerLeaveCheckpoint?.Invoke(playerPool.Get(player.NativeHandle));
	}

	private void HandleNativeOnPlayerEnterRaceCheckpoint(EntityId player)
	{
		PlayerEnterRaceCheckpoint?.Invoke(playerPool.Get(player.NativeHandle));
	}

	private void HandleNativeOnPlayerLeaveRaceCheckpoint(EntityId player)
	{
		PlayerLeaveRaceCheckpoint?.Invoke(playerPool.Get(player.NativeHandle));
	}

}

