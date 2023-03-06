using System.Runtime.InteropServices;

namespace Omp.Net.CApi.Events;

public delegate void OnIncomingConnectionDelegate(UnmanagedEntityId player, string ipAddress, ushort port);
public delegate void OnPlayerConnectDelegate(UnmanagedEntityId player);
public delegate void OnPlayerDisconnectDelegate(UnmanagedEntityId player, int reason);
public delegate void OnPlayerClientInitDelegate(UnmanagedEntityId player);
public delegate int OnPlayerRequestSpawnDelegate(UnmanagedEntityId player);
public delegate void OnPlayerSpawnDelegate(UnmanagedEntityId player);

internal static partial class NativePlayerEvent
{
	public static event OnIncomingConnectionDelegate? NativeOnIncomingConnection;
	public static event OnPlayerConnectDelegate? NativeOnPlayerConnect;
	public static event OnPlayerDisconnectDelegate? NativeOnPlayerDisconnect;
	public static event OnPlayerClientInitDelegate? NativeOnPlayerClientInit;
	public static event OnPlayerRequestSpawnDelegate? NativeOnPlayerRequestSpawn;
	public static event OnPlayerSpawnDelegate? NativeOnPlayerSpawn;

	[UnmanagedCallersOnly()]
	private static void OnIncomingConnection(UnmanagedEntityId player, IntPtr ipAddress, ushort port)
	{
		NativeOnIncomingConnection?.Invoke(player, Marshal.PtrToStringAnsi(ipAddress)!, port);
	}

	[UnmanagedCallersOnly()]
	private static void OnPlayerConnect(UnmanagedEntityId player)
	{
		NativeOnPlayerConnect?.Invoke(player);
	}

	[UnmanagedCallersOnly()]
	private static void OnPlayerDisconnect(UnmanagedEntityId player, int reason)
	{
		NativeOnPlayerDisconnect?.Invoke(player, reason);
	}

	[UnmanagedCallersOnly()]
	private static void OnPlayerClientInit(UnmanagedEntityId player)
	{
		NativeOnPlayerClientInit?.Invoke(player);
	}

	[UnmanagedCallersOnly()]
	private static int OnPlayerRequestSpawn(UnmanagedEntityId player)
	{
		if (NativeOnPlayerRequestSpawn is null)
		{
			return 1;
		}
		return NativeOnPlayerRequestSpawn.Invoke(player);
	}

	[UnmanagedCallersOnly()]
	private static void OnPlayerSpawn(UnmanagedEntityId player)
	{
		NativeOnPlayerSpawn?.Invoke(player);
	}
}
