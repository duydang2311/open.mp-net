using Omp.Net.Entities.Player;
using Omp.Net.Shared;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Events.NativeCustomModelEvent;

namespace Omp.Net;

public delegate void PlayerFinishedDownloadingDelegate(IPlayer player);
public delegate bool PlayerRequestDownloadDelegate(IPlayer player, ModelDownloadType type, uint checksum);

public sealed partial class CoreEvents
{
	public event PlayerFinishedDownloadingDelegate? PlayerFinishedDownloading;
	public event PlayerRequestDownloadDelegate? PlayerRequestDownload;

	private void RegisterCustomModelEvents()
	{
		NativeOnPlayerFinishedDownloading += HandleNativeOnPlayerFinishedDownloading;
		NativeOnPlayerRequestDownload += HandleNativeOnPlayerRequestDownload;
	}

	private void HandleNativeOnPlayerFinishedDownloading(EntityId player)
	{
		PlayerFinishedDownloading?.Invoke(playerPool.Get(player.NativeHandle));
	}

	private bool HandleNativeOnPlayerRequestDownload(EntityId player, ModelDownloadType type, uint checksum)
	{
		return PlayerRequestDownload?.Invoke(playerPool.Get(player.NativeHandle), type, checksum) ?? true;
	}
}
