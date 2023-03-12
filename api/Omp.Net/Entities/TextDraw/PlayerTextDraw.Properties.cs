using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Data;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Natives.PlayerLegacyNative;

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
				LegacyPlayer_GetTextDrawPosition(Player.Id, Id, &x, &y);
				return new Vector2(x, y);
			}
		}
		set
		{
			LegacyPlayer_SetTextDrawPosition(Player.Id, Id, value.X, value.Y);
		}
	}

	public override int Alignment
	{
		get => LegacyPlayer_GetTextDrawAlignment(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawAlignment(Player.Id, Id, value);
		}
	}

	public override Color Color
	{
		get => Color.FromArgb((int)LegacyPlayer_GetTextDrawColor(Player.Id, Id)); set
		{
			LegacyPlayer_SetTextDrawColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}

	public override Color BoxColor
	{
		get => Color.FromArgb((int)LegacyPlayer_GetTextDrawBoxColor(Player.Id, Id)); set
		{
			LegacyPlayer_SetTextDrawBoxColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}

	public override Color BackgroundColor
	{
		get => Color.FromArgb((int)LegacyPlayer_GetTextDrawBackgroundColor(Player.Id, Id)); set
		{
			LegacyPlayer_SetTextDrawBackgroundColor(Player.Id, Id, (uint)value.ToArgb());
		}
	}

	public override TextDrawStyle Style
	{
		get => (TextDrawStyle)LegacyPlayer_GetTextDrawStyle(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawStyle(Player.Id, Id, (int)value);
		}
	}

	public override Vector2 LetterSize
	{
		get
		{
			unsafe
			{
				float x, y;
				LegacyPlayer_GetTextDrawLetterSize(Player.Id, Id, &x, &y);
				return new Vector2(x, y);
			}
		}
		set
		{
			LegacyPlayer_SetTextDrawLetterSize(Player.Id, Id, value.X, value.Y);
		}
	}

	public override int Outline
	{
		get => LegacyPlayer_GetTextDrawOutline(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawOutline(Player.Id, Id, value);
		}
	}

	public override int PreviewModel
	{
		get => LegacyPlayer_GetTextDrawPreviewModel(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawPreviewModel(Player.Id, Id, value);
		}
	}

	public override Vector3 PreviewRotation
	{
		get
		{
			unsafe
			{
				float x, y, z;
				LegacyPlayer_GetTextDrawPreviewRotation(Player.Id, Id, &x, &y, &z);
				return new Vector3(x, y, z);
			}
		}
		set
		{
			LegacyPlayer_SetTextDrawPreviewRotation(Player.Id, Id, value.X, value.Y, value.Z);
		}
	}

	public override float PreviewZoom
	{
		get => LegacyPlayer_GetTextDrawPreviewZoom(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawPreviewZoom(Player.Id, Id, value);
		}
	}

	public override int PreviewVehiclePrimaryColor
	{
		get => LegacyPlayer_GetTextDrawPreviewVehiclePrimaryColor(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawPreviewVehiclePrimaryColor(Player.Id, Id, value);
		}
	}

	public override int PreviewVehicleSecondaryColor
	{
		get => LegacyPlayer_GetTextDrawPreviewVehicleSecondaryColor(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawPreviewVehicleSecondaryColor(Player.Id, Id, value);
		}
	}

	public override bool IsSelectable
	{
		get => LegacyPlayer_IsTextDrawSelectable(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawSelectable(Player.Id, Id, value);
		}
	}

	public override int Shadow
	{
		get => LegacyPlayer_GetTextDrawShadow(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawShadow(Player.Id, Id, value);
		}
	}

	public override bool IsProportional
	{
		get => throw new NotImplementedException(); set
		{
			LegacyPlayer_SetTextDrawProportional(Player.Id, Id, value);
		}
	}

	public override string Text
	{
		get
		{
			var ptr = Marshal.AllocHGlobal(GameConstants.MaxTextDrawStrLength);
			LegacyPlayer_GetTextDrawText(Player.Id, Id, ptr, GameConstants.MaxTextDrawStrLength);
			var name = Marshal.PtrToStringAnsi(ptr, GameConstants.MaxTextDrawStrLength);
			Marshal.FreeHGlobal(ptr);
			return name;
		}
		set
		{
			LegacyPlayer_SetTextDrawText(Player.Id, Id, value);
		}
	}

	public override Vector2 TextSize
	{
		get
		{
			unsafe
			{
				float x, y;
				LegacyPlayer_GetTextDrawTextSize(Player.Id, Id, &x, &y);
				return new Vector2(x, y);
			}
		}
		set
		{
			LegacyPlayer_SetTextDrawTextSize(Player.Id, Id, value.X, value.Y);
		}
	}

	public override bool UseBox
	{
		get => LegacyPlayer_TextDrawHasBox(Player.Id, Id); set
		{
			LegacyPlayer_SetTextDrawUseBox(Player.Id, Id, value);
		}
	}
}
