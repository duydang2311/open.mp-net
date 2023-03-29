using Omp.Net.Entities.Player;
using Omp.Net.Shared;
using static Omp.Net.CApi.Events.NativeMenuEvent;

namespace Omp.Net;

public delegate void PlayerSelectedMenuRowDelegate(IPlayer player, byte row);
public delegate void PlayerExitedMenuDelegate(IPlayer player);

public sealed partial class CoreEvents
{
	public event PlayerSelectedMenuRowDelegate? PlayerSelectedMenuRow;
	public event PlayerExitedMenuDelegate? PlayerExitedMenu;

	private void RegisterMenuEvents()
	{
		NativeOnPlayerSelectedMenuRow += HandleNativeOnPlayerSelectedMenuRow;
		NativeOnPlayerExitedMenu += HandleNativeOnPlayerExitedMenu;
	}

	private void HandleNativeOnPlayerSelectedMenuRow(EntityId player, byte row)
	{
		PlayerSelectedMenuRow?.Invoke(playerPool.Get(player.NativeHandle), row);
	}
	private void HandleNativeOnPlayerExitedMenu(EntityId player)
	{
		PlayerExitedMenu?.Invoke(playerPool.Get(player.NativeHandle));
	}
}
