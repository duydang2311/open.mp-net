using Omp.Net.Entities.Player;
using Omp.Net.Shared;
using static Omp.Net.CApi.Events.NativeClassEvent;

namespace Omp.Net;

public delegate bool PlayerRequestClassDelegate(IPlayer player, uint classId);

public sealed partial class CoreEvents
{
	public event PlayerRequestClassDelegate? PlayerRequestClass;

	private void RegisterClassEvents()
	{
		NativeOnPlayerRequestClass += HandleNativeOnPlayerRequestClass;
	}

	private bool HandleNativeOnPlayerRequestClass(EntityId player, uint classId)
	{
		return PlayerRequestClass?.Invoke(playerPool.Get(player.NativeHandle), classId) ?? true;
	}
}
