using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Events;

public delegate void ScriptStartDelegate();

public static partial class NativeScriptEvent
{
	public static event ScriptStartDelegate? NativeScriptStartEvent;

	[UnmanagedCallersOnly()]
	private static void ScriptStart()
	{
		NativeScriptStartEvent?.Invoke();
	}
}
