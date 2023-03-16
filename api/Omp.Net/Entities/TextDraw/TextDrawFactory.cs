using System.Numerics;
using static Omp.Net.CApi.Natives.TextDrawNative;

namespace Omp.Net.Entities.TextDraw;

public class TextDrawFactory : ITextDrawFactory
{
	public IPlayerTextDraw Create(IPlayer player, Vector2 position, string text)
	{
		return new PlayerTextDraw(player, PlayerTextDraw_CreateText(player.NativeHandle, position, text));
	}

	public IPlayerTextDraw Create(IPlayer player, Vector2 position, int model)
	{
		return new PlayerTextDraw(player, PlayerTextDraw_CreatePreviewModel(player.NativeHandle, position, model));
	}
}
