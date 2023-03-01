namespace Omp.Net.Threading;

public class ActionTickSchedulerFactory : ITickSchedulerFactory
{
	public ITickScheduler Create(Thread mainThread)
	{
		return new ActionTickScheduler();
	}
}
