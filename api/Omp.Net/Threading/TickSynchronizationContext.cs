namespace Omp.Net.Threading;

public sealed class TickSynchronizationContext : SynchronizationContext
{
	private readonly ITickScheduler tickScheduler;

	public TickSynchronizationContext(ITickScheduler tickScheduler)
	{
		this.tickScheduler = tickScheduler;
	}

	public override void Post(SendOrPostCallback d, object? state)
	{
		tickScheduler.Schedule(() => { d.Invoke(state); });
	}
}
