using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Events;

internal delegate void OnDialogResponseDelegate(EntityId player, int dialogId, DialogResponse response, int listItem, string inputText);

internal static class NativeDialogEvent
{
	public static event OnDialogResponseDelegate? NativeOnDialogResponse;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnDialogResponse(EntityId player, int dialogId, DialogResponse response, int listItem, IntPtr inputText)
	{
		NativeOnDialogResponse?.Invoke(player, dialogId, response, listItem, Marshal.PtrToStringAnsi(inputText) ?? string.Empty);
	}
}
