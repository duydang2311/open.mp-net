namespace Omp.Net.Entities.Player;

public class PlayerPool : EntityPool<IPlayer>
{
	public PlayerPool(IEntityFactory<IPlayer> factory) : base(factory) { }
}
