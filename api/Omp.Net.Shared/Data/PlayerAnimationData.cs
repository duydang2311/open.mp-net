namespace Omp.Net.Shared.Data;

public readonly record struct PlayerAnimationData
{
	public ushort Id { get; init; }
	public ushort Flags { get; init; }

	public readonly override string ToString()
	{
		return $"({Id}, {Flags})";
	}
}
