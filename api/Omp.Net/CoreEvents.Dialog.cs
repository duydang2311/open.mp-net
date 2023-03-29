using Omp.Net.Entities.Player;
using Omp.Net.Shared;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Events.NativeDialogEvent;

namespace Omp.Net;

public delegate void DialogResponseDelegate(IPlayer player, int dialogId, DialogResponse response, int listItem, string inputText);

public sealed partial class CoreEvents
{
	public event DialogResponseDelegate? DialogResponse;

	private void RegisterDialogEvents()
	{
		NativeOnDialogResponse += HandleNativeOnDialogResponse;
	}

	public void HandleNativeOnDialogResponse(EntityId player, int dialogId, DialogResponse response, int listItem, string inputText)
	{
		DialogResponse?.Invoke(playerPool.Get(player.NativeHandle), dialogId, response, listItem, inputText);
	}
}
