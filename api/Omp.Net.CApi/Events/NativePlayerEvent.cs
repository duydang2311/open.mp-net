using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Events;

public delegate int PlayerRequestSpawnDelegate(int playerid);

internal static partial class NativePlayerEvent
{
	public static event PlayerRequestSpawnDelegate? NativePlayerRequestSpawnEvent;

	[UnmanagedCallersOnly()]
	private static int PlayerRequestSpawn(int playerid)
	{
		if (NativePlayerRequestSpawnEvent is null)
		{
			return 1;
		}
		return NativePlayerRequestSpawnEvent.Invoke(playerid);
	}
}
