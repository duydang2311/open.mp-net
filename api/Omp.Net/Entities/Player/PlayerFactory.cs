namespace Omp.Net.Entities.Player;

public class PlayerFactory : IEntityFactory<IPlayer>
{
	public IPlayer Create(int id)
	{
		return new BasePlayer(IntPtr.Zero, id);
	}
}
