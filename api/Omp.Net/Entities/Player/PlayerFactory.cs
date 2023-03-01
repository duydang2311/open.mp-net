namespace Omp.Net.Entities.Player;

public class PlayerFactory
{
	public IPlayer CreatePlayer(int id)
	{
		return new BasePlayer(id);
	}
}
