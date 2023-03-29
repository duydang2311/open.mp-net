using Omp.Net.Entities;
using Omp.Net.Entities.Player;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Entities.Vehicle;

namespace Omp.Net;

public sealed partial class CoreEvents
{
	private readonly Core core;
	private readonly IEntityPool<IPlayer> playerPool;
	private readonly IEntityPool<IVehicle> vehiclePool;
	private readonly ITextDrawPool textDrawPool;

	public CoreEvents(Core core)
	{
		this.core = core;
		playerPool = core.PlayerPool;
		vehiclePool = core.VehiclePool;
		textDrawPool = core.GlobalTextDrawPool;

		RegisterCheckpointEvents();
		RegisterClassEvents();
		RegisterCustomModelEvents();
		RegisterDialogEvents();
		RegisterGangZoneEvents();
		RegisterMenuEvents();
		RegisterPlayerEvents();
		RegisterTextDrawEvents();
		RegisterVehicleEvents();
	}
}

