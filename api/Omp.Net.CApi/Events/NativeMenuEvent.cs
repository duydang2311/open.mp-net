using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerSelectedMenuRowDelegate(EntityId player, byte row);
internal delegate void OnPlayerExitedMenuDelegate(EntityId player);

internal static class NativeMenuEvent
{
	public static event OnPlayerSelectedMenuRowDelegate? NativeOnPlayerSelectedMenuRow;
	public static event OnPlayerExitedMenuDelegate? NativeOnPlayerExitedMenu;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerSelectedMenuRow(EntityId player, byte row)
	{
		NativeOnPlayerSelectedMenuRow?.Invoke(player, row);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerExitedMenu(EntityId player)
	{
		NativeOnPlayerExitedMenu?.Invoke(player);
	}
}
