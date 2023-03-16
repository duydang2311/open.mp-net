namespace Omp.Net.Entities.TextDraw;

public interface IPlayerTextDraw : ITextDraw
{
	IPlayer Player { get; }
	bool IsShown { get; }
	void Show();
	void Hide();
}
