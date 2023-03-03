namespace Omp.Net.Shared.Data;

public readonly record struct TimeData
{
	public readonly int Hour { get; init; }
	public readonly int Minute { get; init; }

	public TimeData(int hour, int minute)
	{
		Hour = hour;
		Minute = minute;
	}

	public override readonly string ToString()
	{
		return $"({Hour}, {Minute})";
	}
}
