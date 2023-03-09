using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerFinishedDownloadingDelegate(EntityId player);
internal delegate bool OnPlayerRequestDownloadDelegate(EntityId player, ModelDownloadType type, uint checksum);

internal static class NativeCustomModelEvent
{
	public static event OnPlayerFinishedDownloadingDelegate? NativeOnPlayerFinishedDownloading;
	public static event OnPlayerRequestDownloadDelegate? NativeOnPlayerRequestDownload;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerFinishedDownloading(EntityId player)
	{
		NativeOnPlayerFinishedDownloading?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerRequestDownload(EntityId player, ModelDownloadType type, uint checksum)
	{
		if (NativeOnPlayerRequestDownload is null)
		{
			return 1;
		}
		return NativeOnPlayerRequestDownload(player, type, checksum) ? 1 : 0;
	}
}
