using Omp.Net.Entities;
using Omp.Net.Entities.Player;
using Omp.Net.Entities.Vehicle;

namespace Omp.Net;

public sealed partial class CoreEvents
{
	private readonly Core core;
	private readonly IEntityPool<IPlayer> playerPool;
	private readonly IEntityPool<IVehicle> vehiclePool;

	public CoreEvents(Core core)
	{
		this.core = core;
		playerPool = core.PlayerPool;
		vehiclePool = core.VehiclePool;

		RegisterNativePlayerEvents();
	}
}

