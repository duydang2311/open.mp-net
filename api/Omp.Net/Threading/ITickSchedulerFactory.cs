namespace Omp.Net.Threading;

public interface ITickSchedulerFactory
{
	ITickScheduler Create(Thread mainThread);
}
