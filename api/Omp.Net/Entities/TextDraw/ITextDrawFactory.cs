using System.Numerics;

namespace Omp.Net.Entities.TextDraw;

public interface ITextDrawFactory
{
	IPlayerTextDraw Create(IPlayer player, Vector2 position, string text);
	IPlayerTextDraw Create(IPlayer player, Vector2 position, int model);
}