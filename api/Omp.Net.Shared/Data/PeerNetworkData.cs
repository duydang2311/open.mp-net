namespace Omp.Net.Shared.Data;

public readonly record struct PeerNetworkData
{
	public readonly record struct NetworkID
	{
		public readonly PeerAddress Address { get; init; } ///< The peer's address
		public readonly ushort Port { get; init; } ///< The peer's port
	};

	public readonly IntPtr Network { get; init; } ///< The network associated with the peer
	public readonly NetworkID NetworkId { get; init; } ///< The peer's network ID
};
