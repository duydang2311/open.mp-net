using Omp.Net.CApi.Events;
using static Omp.Net.CApi.Events.NativePlayerEvent;

namespace Omp.Net.Entities;

public partial class BasePlayer
{
	public static event PlayerRequestSpawnDelegate PlayerRequestSpawn
	{
		add
		{
			NativePlayerRequestSpawnEvent += value;
		}
		remove
		{
			NativePlayerRequestSpawnEvent -= value;
		}
	}
}
