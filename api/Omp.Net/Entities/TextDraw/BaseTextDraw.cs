using System.Drawing;
using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Enums;
using static Omp.Net.CApi.Natives.TextDrawNative;

namespace Omp.Net.Entities.TextDraw;

public abstract class BaseTextDraw : ITextDraw
{
	public IntPtr NativeHandle { get; }
	public int Id { get; }

	public BaseTextDraw(IntPtr nativeHandle)
	{
		NativeHandle = nativeHandle;
	}

	public virtual Vector2 Position
	{
		get => TextDrawBase_GetPosition(NativeHandle);
		set => TextDrawBase_SetPosition(NativeHandle, value);
	}

	public virtual TextDrawAlignment Alignment
	{
		get => TextDrawBase_GetAlignment(NativeHandle);
		set => TextDrawBase_SetAlignment(NativeHandle, value);
	}

	public virtual Color Color
	{
		get => Color.FromArgb((int)TextDrawBase_GetLetterColour(NativeHandle));
		set => TextDrawBase_SetColour(NativeHandle, (uint)value.ToArgb());
	}

	public virtual Color BoxColor
	{
		get => Color.FromArgb((int)TextDrawBase_GetBoxColour(NativeHandle));
		set => TextDrawBase_SetBoxColour(NativeHandle, (uint)value.ToArgb());
	}

	public virtual Color BackgroundColor
	{
		get => Color.FromArgb((int)TextDrawBase_GetBackgroundColour(NativeHandle));
		set => TextDrawBase_SetBackgroundColour(NativeHandle, (uint)value.ToArgb());
	}

	public virtual TextDrawStyle Style
	{
		get => TextDrawBase_GetStyle(NativeHandle);
		set => TextDrawBase_SetStyle(NativeHandle, value);
	}

	public virtual Vector2 LetterSize
	{
		get => TextDrawBase_GetLetterSize(NativeHandle);
		set => TextDrawBase_SetLetterSize(NativeHandle, value);
	}

	public virtual int Outline
	{
		get => TextDrawBase_GetOutline(NativeHandle);
		set => TextDrawBase_SetOutline(NativeHandle, value);
	}

	public virtual int PreviewModel
	{
		get => TextDrawBase_GetPreviewModel(NativeHandle);
		set => TextDrawBase_SetPreviewModel(NativeHandle, value);
	}

	public virtual Vector3 PreviewRotation
	{
		get => TextDrawBase_GetPreviewRotation(NativeHandle);
		set => TextDrawBase_SetPreviewRotation(NativeHandle, value);
	}

	public virtual float PreviewZoom
	{
		get => TextDrawBase_GetPreviewZoom(NativeHandle);
		set => TextDrawBase_SetPreviewZoom(NativeHandle, value);
	}

	public virtual bool IsSelectable
	{
		get => TextDrawBase_IsSelectable(NativeHandle);
		set => TextDrawBase_SetSelectable(NativeHandle, value);
	}

	public virtual int Shadow
	{
		get => TextDrawBase_GetShadow(NativeHandle);
		set => TextDrawBase_SetShadow(NativeHandle, value);
	}

	public virtual bool IsProportional
	{
		get => TextDrawBase_IsProportional(NativeHandle);
		set => TextDrawBase_SetProportional(NativeHandle, value);
	}

	public virtual string Text
	{
		get
		{
			var ptr = TextDrawBase_GetText(NativeHandle);
			var name = Marshal.PtrToStringAnsi(ptr);
			return name ?? string.Empty;
		}
		set => TextDrawBase_SetText(NativeHandle, value);
	}

	public virtual Vector2 TextSize
	{
		get => TextDrawBase_GetTextSize(NativeHandle);
		set => TextDrawBase_SetTextSize(NativeHandle, value);
	}

	public virtual bool UseBox
	{
		get => TextDrawBase_HasBox(NativeHandle);
		set => TextDrawBase_UseBox(NativeHandle, value);
	}

	public virtual void GetPreviewVehicleColor(out int primaryColor, out int secondaryColor)
	{
		unsafe
		{
			int primaryColor_, secondaryColor_;
			TextDrawBase_GetPreviewVehicleColour(NativeHandle, &primaryColor_, &secondaryColor_);
			primaryColor = primaryColor_;
			secondaryColor = secondaryColor_;
		}
	}

	public virtual void SetPreviewVehicleColor(int primaryColor, int secondaryColor)
	{
		TextDrawBase_SetPreviewVehicleColour(NativeHandle, primaryColor, secondaryColor);
	}

	public virtual void Restream()
	{
		TextDrawBase_Restream(NativeHandle);
	}
}
