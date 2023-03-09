using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Events;

internal delegate void OnPlayerGiveDamageActorDelegate(EntityId player, EntityId actor, float amount, uint weapon, BodyPart part);
internal delegate void OnActorStreamOutDelegate(EntityId actor, EntityId forPlayer);
internal delegate void OnActorStreamInDelegate(EntityId actor, EntityId forPlayer);

internal static class NativeActorEvent
{
	public static event OnPlayerGiveDamageActorDelegate? NativeOnPlayerGiveDamageActor;
	public static event OnActorStreamOutDelegate? NativeOnActorStreamOut;
	public static event OnActorStreamInDelegate? NativeOnActorStreamIn;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnPlayerGiveDamageActor(EntityId player, EntityId actor, float amount, uint weapon, BodyPart part)
	{
		NativeOnPlayerGiveDamageActor?.Invoke(player, actor, amount, weapon, part);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnActorStreamOut(EntityId actor, EntityId forPlayer)
	{
		NativeOnActorStreamOut?.Invoke(actor, forPlayer);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnActorStreamIn(EntityId actor, EntityId forPlayer)
	{
		NativeOnActorStreamIn?.Invoke(actor, forPlayer);
	}
}
