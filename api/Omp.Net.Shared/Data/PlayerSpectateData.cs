namespace Omp.Net.Shared.Data;

public readonly record struct PlayerSpectateData
{
	public enum SpectateType
	{
		None,
		Vehicle,
		Player
	};

	public readonly bool Spectating { get; init; }
	public readonly int SpectateID { get; init; }
	public readonly SpectateType Type { get; init; }

	public readonly override string ToString()
	{
		return $"({Spectating}, {SpectateID}, {Type})";
	}
};
