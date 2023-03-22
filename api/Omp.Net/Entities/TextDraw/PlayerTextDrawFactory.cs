using System.Numerics;
using Omp.Net.Entities.Player;
using static Omp.Net.CApi.Natives.TextDrawNative;

namespace Omp.Net.Entities.TextDraw;

public class PlayerTextDrawFactory : ITextDrawFactory
{
	private readonly IPlayer player;

	public PlayerTextDrawFactory(IPlayer player)
	{
		this.player = player;
	}

	public ITextDraw Create(Vector2 position, string text)
	{
		return new PlayerTextDraw(player, PlayerTextDraw_CreateText(player.NativeHandle, position, text));
	}

	public ITextDraw Create(Vector2 position, int model)
	{
		return new PlayerTextDraw(player, PlayerTextDraw_CreatePreviewModel(player.NativeHandle, position, model));
	}
}
