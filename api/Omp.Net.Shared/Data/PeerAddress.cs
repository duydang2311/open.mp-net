namespace Omp.Net.Shared.Data;

public readonly record struct PeerAddress
{
	public readonly record struct Ipv6
	{
		public readonly ushort[] Segments { get; init; } ///< The IPv6 address segments
		public readonly byte[] Bytes { get; init; } ///< The IPv6 address bytes
	}

	public readonly bool IsV6 { get; init; } ///< True if IPv6 is used, false otherwise
	public readonly uint V4 { get; init; } ///< The IPv4 address
	public readonly Ipv6 V6 { get; init; }

	public readonly override string ToString()
	{
		return $"({IsV6}, {V4}, {V6})";
	}
};
