using System.Numerics;

namespace Omp.Net.Entities.TextDraw;

public interface ITextDrawFactory
{
	ITextDraw Create(Vector2 position, string text);
	ITextDraw Create(Vector2 position, int model);
}