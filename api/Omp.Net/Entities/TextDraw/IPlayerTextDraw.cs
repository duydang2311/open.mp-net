namespace Omp.Net.Entities.TextDraw;

public interface IPlayerTextDraw : ITextDraw
{
	IPlayer Player { get; }
	bool Show();
	bool Hide();
	bool Restream();
}
