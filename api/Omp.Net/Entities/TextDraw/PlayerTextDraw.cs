using System.Numerics;
using static Omp.Net.CApi.Natives.PlayerNative;

namespace Omp.Net.Entities.TextDraw;

public partial class PlayerTextDraw : BaseTextDraw, IPlayerTextDraw
{
	public IPlayer Player { get; }

	public PlayerTextDraw(IPlayer player, Vector2 position, int model) : this(player, CreatePlayerPreviewModelTextDrawInternal(player.Id, position, model)) { }

	public PlayerTextDraw(IPlayer player, Vector2 position, string text) : this(player, CreatePlayerTextDrawInternal(player.Id, position, text)) { }

	public PlayerTextDraw(IPlayer player, int id) : base(id)
	{
		Player = player;
	}

	public bool Hide()
	{
		return Player_HideTextDraw(Player.Id, Id);
	}

	public bool Show()
	{
		return Player_ShowTextDraw(Player.Id, Id);
	}

	public bool Restream()
	{
		return Player_RestreamTextDraw(Player.Id, Id);
	}

	private static int CreatePlayerTextDrawInternal(int playerid, Vector2 position, string text)
	{
		return Player_CreateTextDraw(playerid, position.X, position.Y, text);
	}

	private static int CreatePlayerPreviewModelTextDrawInternal(int playerid, Vector2 position, int model)
	{
		return Player_CreatePreviewModelTextDraw(playerid, position.X, position.Y, model);
	}
}
