namespace Omp.Net.Shared.Data;

public readonly record struct TimeData
{
	public readonly long Hour { get; init; }
	public readonly long Minute { get; init; }

	public TimeData(long hour, long minute)
	{
		Hour = hour;
		Minute = minute;
	}

	public override readonly string ToString()
	{
		return $"({Hour}, {Minute})";
	}
}
