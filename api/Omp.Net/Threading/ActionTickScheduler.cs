using System.Collections.Concurrent;

namespace Omp.Net.Threading;

internal class ActionTickScheduler : ITickScheduler
{
	private readonly ConcurrentQueue<Action<ITickScheduler>> actions = new();

	public ActionTickScheduler()
	{
	}

	public void Schedule(Action action)
	{
		actions.Enqueue(new ActionContainer(action).Run);
	}

	public Task<T> ScheduleAsync<T>(Func<Task<T>> action)
	{
		var completionSource = new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously);
		actions.Enqueue(new AsyncActionContainer<T>(action, completionSource).Run);
		return completionSource.Task;
	}

	public Task ScheduleAsync(Func<Task> action)
	{
		var completionSource = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
		actions.Enqueue(new AsyncActionContainer(action, completionSource).Run);
		return completionSource.Task;
	}

	public void Tick()
	{
		if (actions.TryDequeue(out var run))
		{
			run(this);
		}
	}

	private readonly struct ActionContainer
	{
		private readonly Action action;

		public ActionContainer(Action action)
		{
			this.action = action;
		}

		public void Run(ITickScheduler scheduler)
		{
			var previousContext = SynchronizationContext.Current;
			try
			{
				var tickContext = new TickSynchronizationContext(scheduler);
				SynchronizationContext.SetSynchronizationContext(tickContext);
				tickContext.OperationStarted();
				action();
				tickContext.OperationCompleted();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(previousContext);
			}
		}
	}

	private readonly struct AsyncActionContainer<T>
	{
		private readonly Func<Task<T>> func;
		private readonly TaskCompletionSource<T> source;

		public AsyncActionContainer(Func<Task<T>> func, TaskCompletionSource<T> source)
		{
			this.func = func;
			this.source = source;
		}

		public async void Run(ITickScheduler scheduler)
		{
			var previousContext = SynchronizationContext.Current;
			try
			{
				var tickContext = new TickSynchronizationContext(scheduler);
				SynchronizationContext.SetSynchronizationContext(tickContext);
				source.SetResult(await func());
			}
			catch (Exception ex)
			{
				source.SetResult(default!);
				source.SetException(ex);
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(previousContext);
			}
		}
	}
	private readonly struct AsyncActionContainer
	{
		private readonly Func<Task> func;
		private readonly TaskCompletionSource source;

		public AsyncActionContainer(Func<Task> func, TaskCompletionSource source)
		{
			this.func = func;
			this.source = source;
		}

		public async void Run(ITickScheduler scheduler)
		{
			var previousContext = SynchronizationContext.Current;
			try
			{
				var tickContext = new TickSynchronizationContext(scheduler);
				SynchronizationContext.SetSynchronizationContext(tickContext);
				await func();
			}
			catch (Exception ex)
			{
				source.SetException(ex);
			}
			finally
			{
				source.SetResult();
				SynchronizationContext.SetSynchronizationContext(previousContext);
			}
		}
	}
}
