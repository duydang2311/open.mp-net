using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerClickTextDrawDelegate(EntityId player, EntityId td);
internal delegate void OnPlayerClickPlayerTextDrawDelegate(EntityId player, EntityId td);
internal delegate bool OnPlayerCancelTextDrawSelectionDelegate(EntityId player);
internal delegate bool OnPlayerCancelPlayerTextDrawSelectionDelegate(EntityId player);

internal static class NativeTextDrawEvent
{
	public static event OnPlayerClickTextDrawDelegate? NativeOnPlayerClickTextDraw;
	public static event OnPlayerClickPlayerTextDrawDelegate? NativeOnPlayerClickPlayerTextDraw;
	public static event OnPlayerCancelTextDrawSelectionDelegate? NativeOnPlayerCancelTextDrawSelection;
	public static event OnPlayerCancelPlayerTextDrawSelectionDelegate? NativeOnPlayerCancelPlayerTextDrawSelection;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerClickTextDraw(EntityId player, EntityId td)
	{
		NativeOnPlayerClickTextDraw?.Invoke(player, td);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerClickPlayerTextDraw(EntityId player, EntityId td)
	{
		NativeOnPlayerClickPlayerTextDraw?.Invoke(player, td);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerCancelTextDrawSelection(EntityId player)
	{
		if (NativeOnPlayerCancelTextDrawSelection is null)
		{
			return 1;
		}
		return NativeOnPlayerCancelTextDrawSelection(player) ? 1 : 0;
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerCancelPlayerTextDrawSelection(EntityId player)
	{
		if (NativeOnPlayerCancelPlayerTextDrawSelection is null)
		{
			return 1;
		}
		return NativeOnPlayerCancelPlayerTextDrawSelection(player) ? 1 : 0;
	}
}
