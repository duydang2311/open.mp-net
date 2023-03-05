using System.Numerics;

namespace Omp.Net.Entities.TextDraw;

public class TextDrawFactory : ITextDrawFactory
{
	public IPlayerTextDraw Create(IPlayer player, Vector2 position, string text)
	{
		return new PlayerTextDraw(player, position, text);
	}

	public IPlayerTextDraw Create(IPlayer player, Vector2 position, int model)
	{
		return new PlayerTextDraw(player, position, model);
	}
}
