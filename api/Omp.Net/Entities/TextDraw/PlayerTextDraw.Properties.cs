using System.Drawing;
using System.Numerics;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Natives.PlayerNative;

namespace Omp.Net.Entities.TextDraw;

public partial class PlayerTextDraw
{
	public override Vector2 Position
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawPosition(Player.Id, Id, value.X, value.Y);
		}
	}
	public override int Alignment
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawAlignment(Player.Id, Id, value);
		}
	}
	public override Color Color
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}
	public override Color BoxColor
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawBoxColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}
	public override Color BackgroundColor
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawBackgroundColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}
	public override TextDrawStyle Style
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawStyle(Player.Id, Id, (int)value);
		}
	}
	public override Vector2 LetterSize
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawLetterSize(Player.Id, Id, value.X, value.Y);
		}
	}
	public override int Outline
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawOutline(Player.Id, Id, value);
		}
	}
	public override int PreviewModel
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawPreviewModel(Player.Id, Id, value);
		}
	}
	public override Vector3 PreviewRotation
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawPreviewRotation(Player.Id, Id, value.X, value.Y, value.Z);
		}
	}
	public override float PreviewZoom
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawPreviewZoom(Player.Id, Id, value);
		}
	}
	public override int PreviewVehiclePrimaryColor
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawPreviewVehiclePrimaryColor(Player.Id, Id, value);
		}
	}
	public override int PreviewVehicleSecondaryColor
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawPreviewVehicleSecondaryColor(Player.Id, Id, value);
		}
	}
	public override bool IsSelectable
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawSelectable(Player.Id, Id, value);
		}
	}
	public override int Shadow
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawShadow(Player.Id, Id, value);
		}
	}
	public override bool IsProportional
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawProportional(Player.Id, Id, value);
		}
	}
	public override string Text
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawText(Player.Id, Id, value);
		}
	}
	public override Vector2 TextSize
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawTextSize(Player.Id, Id, value.X, value.Y);
		}
	}
	public override bool UseBox
	{
		get => throw new NotImplementedException(); set
		{
			Player_SetTextDrawUseBox(Player.Id, Id, value);
		}
	}
}
