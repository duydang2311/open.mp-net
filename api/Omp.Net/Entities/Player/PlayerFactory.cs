namespace Omp.Net.Entities.Player;

public class PlayerFactory : IPlayerFactory
{
	public PlayerFactory() { }

	public IPlayer CreatePlayer(IntPtr nativeHandle, int id)
	{
		return new BasePlayer(nativeHandle, id);
	}
}
