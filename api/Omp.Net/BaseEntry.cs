using Omp.Net.Entities.Player;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Threading;

namespace Omp.Net;

public abstract class BaseEntry
{
	public abstract void OnReady();

	public virtual IPlayerFactory GetPlayerFactory()
	{
		return new PlayerFactory();
	}

	public virtual ITextDrawFactory GetTextDrawFactory()
	{
		return new TextDrawFactory();
	}

	public virtual ITickSchedulerFactory GetTickSchedulerFactory()
	{
		return new ActionTickSchedulerFactory();
	}
}
