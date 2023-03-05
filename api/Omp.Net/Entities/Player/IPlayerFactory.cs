namespace Omp.Net.Entities.Player;

public interface IPlayerFactory
{
	IPlayer CreatePlayer(IntPtr nativeHandle, int id);
}
