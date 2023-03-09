using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerPickUpPickupDelegate(EntityId player, EntityId pickup);

internal static class NativePickupEvent
{
	public static event OnPlayerPickUpPickupDelegate? NativeOnPlayerPickUpPickup;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerPickUpPickup(EntityId player, EntityId pickup)
	{
		NativeOnPlayerPickUpPickup?.Invoke(player, pickup);
	}
}
