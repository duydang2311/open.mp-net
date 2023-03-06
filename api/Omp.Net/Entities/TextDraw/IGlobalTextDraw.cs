namespace Omp.Net.Entities.TextDraw;

public interface IGlobalTextDraw : ITextDraw
{
	bool ShowFor(IPlayer player);
	bool ShowForAll();
	bool HideFor(IPlayer player);
	bool HideForAll();
}
