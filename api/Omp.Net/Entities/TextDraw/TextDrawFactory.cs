using System.Numerics;
using static Omp.Net.CApi.Natives.TextDrawNative;

namespace Omp.Net.Entities.TextDraw;

public class TextDrawFactory : ITextDrawFactory
{
	public ITextDraw Create(Vector2 position, string text)
	{
		return new GlobalTextDraw(TextDraw_CreateText(position, text));
	}

	public ITextDraw Create(Vector2 position, int model)
	{
		return new GlobalTextDraw(TextDraw_CreatePreviewModel(position, model));
	}
}
