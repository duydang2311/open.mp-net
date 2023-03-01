namespace Omp.Net.Threading;

public interface ITickScheduler
{
	void Tick();
	void Schedule(Action action);
	Task<T> ScheduleAsync<T>(Func<Task<T>> action);
	Task ScheduleAsync(Func<Task> action);
}
