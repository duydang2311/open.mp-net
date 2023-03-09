using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerEnterGangZoneDelegate(EntityId player, int zoneId);
internal delegate void OnPlayerLeaveGangZoneDelegate(EntityId player, int zoneId);
internal delegate void OnPlayerClickGangZoneDelegate(EntityId player, int zoneId);

internal static class NativeGangZoneEvent
{
	public static event OnPlayerEnterGangZoneDelegate? NativeOnPlayerEnterGangZone;
	public static event OnPlayerLeaveGangZoneDelegate? NativeOnPlayerLeaveGangZone;
	public static event OnPlayerClickGangZoneDelegate? NativeOnPlayerClickGangZone;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerEnterGangZone(EntityId player, int zoneId)
	{
		NativeOnPlayerEnterGangZone?.Invoke(player, zoneId);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerLeaveGangZone(EntityId player, int zoneId)
	{
		NativeOnPlayerLeaveGangZone?.Invoke(player, zoneId);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerClickGangZone(EntityId player, int zoneId)
	{
		NativeOnPlayerClickGangZone?.Invoke(player, zoneId);
	}
}
