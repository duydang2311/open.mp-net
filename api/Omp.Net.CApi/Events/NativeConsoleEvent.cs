using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.Shared;

namespace Omp.Net.CApi.Events;

internal delegate bool OnConsoleTextDelegate(string command, string parameters, int senderType);
internal delegate void OnRconLoginAttemptDelegate(EntityId player, string password, bool success);
internal unsafe delegate void OnConsoleCommandListRequestDelegate(HashSet<string> commands);

internal static partial class NativeConsoleEvent
{
	public static event OnConsoleTextDelegate? NativeOnConsoleText;
	public static event OnRconLoginAttemptDelegate? NativeOnRconLoginAttempt;
	public static event OnConsoleCommandListRequestDelegate? NativeOnConsoleCommandListRequest;

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static unsafe int OnConsoleText(IntPtr command, IntPtr parameters, void* senderDataPtr)
	{
		// TODO: maybe marshal the whole senderData struct
		if (NativeOnConsoleText is null)
		{
			return 1;
		}
		unsafe
		{
			var senderType = *((int*)senderDataPtr + 0);
			var ret = NativeOnConsoleText(Marshal.PtrToStringAnsi(command) ?? string.Empty, Marshal.PtrToStringAnsi(parameters) ?? string.Empty, senderType);
			return *(int*)&ret;
		}
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void OnRconLoginAttempt(EntityId player, IntPtr password, bool success)
	{
		NativeOnRconLoginAttempt?.Invoke(player, Marshal.PtrToStringAnsi(password) ?? string.Empty, success);
	}

	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static unsafe void OnConsoleCommandListRequest(void* commandHashSet)
	{
		// TODO: marshal a hash set of strings
		NativeOnConsoleCommandListRequest?.Invoke(new HashSet<string>());
	}
}
