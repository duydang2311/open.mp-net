using Omp.Net.Shared.Enums;

namespace Omp.Net.Shared.Data;

public readonly record struct KeysData
{
	public readonly GameKey Key { get; init; }
	public readonly GameKey LeftRight { get; init; }
	public readonly GameKey UpDown { get; init; }

	public KeysData(GameKey key, GameKey upDown, GameKey leftRight)
	{
		Key = key;
		LeftRight = leftRight;
		UpDown = upDown;
	}

	public override readonly string ToString()
	{
		return $"({Key}, {UpDown}, {LeftRight})";
	}
}
