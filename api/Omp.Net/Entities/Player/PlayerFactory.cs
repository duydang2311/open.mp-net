namespace Omp.Net.Entities.Player;

public class PlayerFactory : IEntityFactory<IPlayer>
{
	public IPlayer Create(IntPtr nativeHandle, int id)
	{
		return new BasePlayer(nativeHandle, id);
	}
}
