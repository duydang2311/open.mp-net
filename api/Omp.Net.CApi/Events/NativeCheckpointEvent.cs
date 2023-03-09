using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerEnterCheckpointDelegate(EntityId player);
internal delegate void OnPlayerLeaveCheckpointDelegate(EntityId player);
internal delegate void OnPlayerEnterRaceCheckpointDelegate(EntityId player);
internal delegate void OnPlayerLeaveRaceCheckpointDelegate(EntityId player);

internal static class NativeCheckpointEvent
{
	public static event OnPlayerEnterCheckpointDelegate? NativeOnPlayerEnterCheckpoint;
	public static event OnPlayerLeaveCheckpointDelegate? NativeOnPlayerLeaveCheckpoint;
	public static event OnPlayerEnterRaceCheckpointDelegate? NativeOnPlayerEnterRaceCheckpoint;
	public static event OnPlayerLeaveRaceCheckpointDelegate? NativeOnPlayerLeaveRaceCheckpoint;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerEnterCheckpoint(EntityId player)
	{
		NativeOnPlayerEnterCheckpoint?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerLeaveCheckpoint(EntityId player)
	{
		NativeOnPlayerLeaveCheckpoint?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerEnterRaceCheckpoint(EntityId player)
	{
		NativeOnPlayerEnterRaceCheckpoint?.Invoke(player);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerLeaveRaceCheckpoint(EntityId player)
	{
		NativeOnPlayerLeaveRaceCheckpoint?.Invoke(player);
	}
}
