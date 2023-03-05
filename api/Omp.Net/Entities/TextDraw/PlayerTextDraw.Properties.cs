using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Natives.PlayerNative;

namespace Omp.Net.Entities.TextDraw;

public partial class PlayerTextDraw
{
	public override Vector2 Position
	{
		get
		{
			unsafe
			{
				float x, y;
				Player_GetTextDrawPosition(Player.Id, Id, &x, &y);
				return new Vector2(x, y);
			}
		}
		set
		{
			Player_SetTextDrawPosition(Player.Id, Id, value.X, value.Y);
		}
	}

	public override int Alignment
	{
		get => Player_GetTextDrawAlignment(Player.Id, Id); set
		{
			Player_SetTextDrawAlignment(Player.Id, Id, value);
		}
	}

	public override Color Color
	{
		get => Color.FromArgb((int)Player_GetTextDrawColor(Player.Id, Id)); set
		{
			Player_SetTextDrawColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}

	public override Color BoxColor
	{
		get => Color.FromArgb((int)Player_GetTextDrawBoxColor(Player.Id, Id)); set
		{
			Player_SetTextDrawBoxColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}

	public override Color BackgroundColor
	{
		get => Color.FromArgb((int)Player_GetTextDrawBackgroundColor(Player.Id, Id)); set
		{
			Player_SetTextDrawBackgroundColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}

	public override TextDrawStyle Style
	{
		get => (TextDrawStyle)Player_GetTextDrawStyle(Player.Id, Id); set
		{
			Player_SetTextDrawStyle(Player.Id, Id, (int)value);
		}
	}

	public override Vector2 LetterSize
	{
		get
		{
			unsafe
			{
				float x, y;
				Player_GetTextDrawLetterSize(Player.Id, Id, &x, &y);
				return new Vector2(x, y);
			}
		}
		set
		{
			Player_SetTextDrawLetterSize(Player.Id, Id, value.X, value.Y);
		}
	}

	public override int Outline
	{
		get => Player_GetTextDrawOutline(Player.Id, Id); set
		{
			Player_SetTextDrawOutline(Player.Id, Id, value);
		}
	}

	public override int PreviewModel
	{
		get => Player_GetTextDrawPreviewModel(Player.Id, Id); set
		{
			Player_SetTextDrawPreviewModel(Player.Id, Id, value);
		}
	}

	public override Vector3 PreviewRotation
	{
		get
		{
			unsafe
			{
				float x, y, z;
				Player_GetTextDrawPreviewRotation(Player.Id, Id, &x, &y, &z);
				return new Vector3(x, y, z);
			}
		}
		set
		{
			Player_SetTextDrawPreviewRotation(Player.Id, Id, value.X, value.Y, value.Z);
		}
	}

	public override float PreviewZoom
	{
		get => Player_GetTextDrawPreviewZoom(Player.Id, Id); set
		{
			Player_SetTextDrawPreviewZoom(Player.Id, Id, value);
		}
	}

	public override int PreviewVehiclePrimaryColor
	{
		get => Player_GetTextDrawPreviewVehiclePrimaryColor(Player.Id, Id); set
		{
			Player_SetTextDrawPreviewVehiclePrimaryColor(Player.Id, Id, value);
		}
	}

	public override int PreviewVehicleSecondaryColor
	{
		get => Player_GetTextDrawPreviewVehicleSecondaryColor(Player.Id, Id); set
		{
			Player_SetTextDrawPreviewVehicleSecondaryColor(Player.Id, Id, value);
		}
	}

	public override bool IsSelectable
	{
		get => Player_IsTextDrawSelectable(Player.Id, Id); set
		{
			Player_SetTextDrawSelectable(Player.Id, Id, value);
		}
	}

	public override int Shadow
	{
		get => Player_GetTextDrawShadow(Player.Id, Id); set
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
		get
		{
			var ptr = Marshal.AllocHGlobal(GameConstants.MaxTextDrawStrLength);
			Player_GetTextDrawText(Player.Id, Id, ptr, GameConstants.MaxTextDrawStrLength);
			var name = Marshal.PtrToStringAnsi(ptr, GameConstants.MaxTextDrawStrLength);
			Marshal.FreeHGlobal(ptr);
			return name;
		}
		set
		{
			Player_SetTextDrawText(Player.Id, Id, value);
		}
	}

	public override Vector2 TextSize
	{
		get
		{
			unsafe
			{
				float x, y;
				Player_GetTextDrawTextSize(Player.Id, Id, &x, &y);
				return new Vector2(x, y);
			}
		}
		set
		{
			Player_SetTextDrawTextSize(Player.Id, Id, value.X, value.Y);
		}
	}

	public override bool UseBox
	{
		get => Player_TextDrawHasBox(Player.Id, Id); set
		{
			Player_SetTextDrawUseBox(Player.Id, Id, value);
		}
	}
}
