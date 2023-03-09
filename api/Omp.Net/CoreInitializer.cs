using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Omp.Net.CApi.Events;

namespace Omp.Net;

internal static class CoreInitializer
{
	[UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
	private static void InitializeCore(IntPtr ptr)
	{
		var asmName = Marshal.PtrToStringAnsi(ptr)!;
		var asm = Assembly.Load(asmName);
		if (asm is null)
		{
			throw new DllNotFoundException($"Entry assembly {asmName} not found");
		}

		var startupType = asm.GetTypes().Where(t => !t.IsInterface && !t.IsAbstract && t.IsAssignableTo(typeof(BaseEntry))).FirstOrDefault();
		if (startupType is null)
		{
			throw new EntryPointNotFoundException($"Startup type not found, consider providing a class inheriting from Omp.Net.Startup");
		}

		var instance = asm.CreateInstance(startupType.FullName!);
		if (instance is null)
		{
			throw new NullReferenceException($"Unable to create an instance of candidate startup type {startupType.Name}");
		}

		var entry = (BaseEntry)instance;
		NativeCoreEvent.NativeOnReady += entry.OnReady;

		_ = new Core(entry);
	}
}
