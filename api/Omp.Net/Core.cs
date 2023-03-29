using System.Runtime.InteropServices;
using Omp.Net.CApi.Natives;
using Omp.Net.Entities;
using Omp.Net.Entities.Player;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Entities.Vehicle;
using Omp.Net.Threading;

namespace Omp.Net;

public sealed partial class Core
{
	public static Core Instance { get; private set; } = null!;

	public CoreEvents Events { get; }
	public IEntityPool<IPlayer> PlayerPool { get; }
	public IEntityPool<IVehicle> VehiclePool { get; }
	public ITextDrawPool GlobalTextDrawPool { get; }
	public ITextDrawFactory TextDrawFactory => textDrawFactory;

	internal Core(BaseEntry entry)
	{
		Instance = this;
		this.entry = entry;

		Events = new CoreEvents(this);
		PlayerPool = new PlayerPool(entry.GetPlayerFactory());
		VehiclePool = new VehiclePool(entry.GetVehicleFactory());
		GlobalTextDrawPool = new TextDrawPool(entry.GetTextDrawFactory());
		textDrawFactory = entry.GetTextDrawFactory();
		tickSchedulerFactory = entry.GetTickSchedulerFactory();
		tickScheduler = tickSchedulerFactory.Create(Thread.CurrentThread);

		tickDelegate = tickScheduler.Tick;
		CoreNative.Core_SetTickDelegate(Marshal.GetFunctionPointerForDelegate(tickDelegate));
	}

	public void Invoke(Action action)
	{
		tickScheduler.Schedule(action);
	}

	public Task InvokeAsync(Func<Task> func)
	{
		return tickScheduler.ScheduleAsync(func);
	}

	public Task<T> InvokeAsync<T>(Func<Task<T>> func)
	{
		return tickScheduler.ScheduleAsync(func);
	}

	public ITextDrawFactory GetPlayerTextDrawFactory(IPlayer player)
	{
		return entry.GetPlayerTextDrawFactory(player);
	}

	private delegate void TickDelegate();
	private readonly ITickScheduler tickScheduler;
	private readonly TickDelegate tickDelegate;
	private readonly ITickSchedulerFactory tickSchedulerFactory;
	private readonly ITextDrawFactory textDrawFactory;
	private readonly BaseEntry entry;
}
