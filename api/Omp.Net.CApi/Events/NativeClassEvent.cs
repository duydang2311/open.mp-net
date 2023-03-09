using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate bool OnPlayerRequestClassDelegate(EntityId player, uint classId);

internal static class NativeClassEvent
{
	public static event OnPlayerRequestClassDelegate? NativeOnPlayerRequestClass;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static int OnPlayerRequestClass(EntityId player, uint classId)
	{
		if (NativeOnPlayerRequestClass is null)
		{
			return 1;
		}
		return NativeOnPlayerRequestClass(player, classId) ? 1 : 0;
	}
}
