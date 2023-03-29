using Omp.Net.Entities.Player;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Shared;
using static Omp.Net.CApi.Events.NativeTextDrawEvent;

namespace Omp.Net;

public delegate void PlayerClickTextDrawDelegate(IPlayer player, ITextDraw td);
public delegate void PlayerClickPlayerTextDrawDelegate(IPlayer player, ITextDraw td);
public delegate bool PlayerCancelTextDrawSelectionDelegate(IPlayer player);
public delegate bool PlayerCancelPlayerTextDrawSelectionDelegate(IPlayer player);

public sealed partial class CoreEvents
{
	public event PlayerClickTextDrawDelegate? PlayerClickTextDraw;
	public event PlayerClickPlayerTextDrawDelegate? PlayerClickPlayerTextDraw;
	public event PlayerCancelTextDrawSelectionDelegate? PlayerCancelTextDrawSelection;
	public event PlayerCancelPlayerTextDrawSelectionDelegate? PlayerCancelPlayerTextDrawSelection;

	private void RegisterTextDrawEvents()
	{
		NativeOnPlayerClickTextDraw += HandleNativeOnPlayerClickTextDraw;
		NativeOnPlayerClickPlayerTextDraw += HandleNativeOnPlayerClickPlayerTextDraw;
		NativeOnPlayerCancelTextDrawSelection += HandleNativeOnPlayerCancelTextDrawSelection;
		NativeOnPlayerCancelPlayerTextDrawSelection += HandleNativeOnPlayerCancelPlayerTextDrawSelection;
	}

	private void HandleNativeOnPlayerClickTextDraw(EntityId player, EntityId td)
	{
		if (PlayerClickTextDraw is null
		|| !textDrawPool.TryGet(td.NativeHandle, out var textDraw))
		{
			return;
		}
		PlayerClickTextDraw.Invoke(playerPool.Get(player.NativeHandle), textDraw);
	}
	private void HandleNativeOnPlayerClickPlayerTextDraw(EntityId player, EntityId td)
	{
		var pooledPlayer = playerPool.Get(player.NativeHandle);
		var clickedTD = pooledPlayer.TextDraws.FirstOrDefault(playerTD => playerTD.NativeHandle == td.NativeHandle);
		if (clickedTD is null)
		{
			return;
		}
		PlayerClickPlayerTextDraw?.Invoke(pooledPlayer, clickedTD);
	}
	private bool HandleNativeOnPlayerCancelTextDrawSelection(EntityId player)
	{
		return PlayerCancelTextDrawSelection?.Invoke(playerPool.Get(player.NativeHandle)) ?? true;
	}
	private bool HandleNativeOnPlayerCancelPlayerTextDrawSelection(EntityId player)
	{
		return PlayerCancelPlayerTextDrawSelection?.Invoke(playerPool.Get(player.NativeHandle)) ?? true;
	}
}
