using Omp.Net.Entities;
using Omp.Net.Entities.Player;
using Omp.Net.Entities.TextDraw;
using Omp.Net.Threading;

namespace Omp.Net;

public abstract class BaseEntry
{
	public abstract void OnReady();

	public virtual IEntityFactory<IPlayer> GetPlayerFactory()
	{
		return new PlayerFactory();
	}

	public virtual ITextDrawFactory GetTextDrawFactory()
	{
		return new TextDrawFactory();
	}

	public virtual ITextDrawFactory GetPlayerTextDrawFactory(IPlayer player)
	{
		return new PlayerTextDrawFactory(player);
	}

	public virtual ITickSchedulerFactory GetTickSchedulerFactory()
	{
		return new ActionTickSchedulerFactory();
	}
}
