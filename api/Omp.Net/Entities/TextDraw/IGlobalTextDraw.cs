using Omp.Net.Entities.Player;

namespace Omp.Net.Entities.TextDraw;

public interface IGlobalTextDraw : ITextDraw
{
	void ShowFor(IPlayer player);
	void HideFor(IPlayer player);
	bool IsShownFor(IPlayer player);
}
