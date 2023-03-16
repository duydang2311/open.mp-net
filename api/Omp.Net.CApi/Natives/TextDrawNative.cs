using System.Numerics;
using System.Runtime.InteropServices;
using Omp.Net.Shared.Enums;

namespace Omp.Net.CApi.Natives;

internal static class TextDrawNative
{
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector2 TextDrawBase_GetPosition(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetPosition(IntPtr td, Vector2 position);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetText(IntPtr td, string text);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr TextDrawBase_GetText(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetLetterSize(IntPtr td, Vector2 size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector2 TextDrawBase_GetLetterSize(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetTextSize(IntPtr td, Vector2 size);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector2 TextDrawBase_GetTextSize(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetAlignment(IntPtr td, TextDrawAlignment alignment);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern TextDrawAlignment TextDrawBase_GetAlignment(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetColour(IntPtr td, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint TextDrawBase_GetLetterColour(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_UseBox(IntPtr td, bool use);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool TextDrawBase_HasBox(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetBoxColour(IntPtr td, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint TextDrawBase_GetBoxColour(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetShadow(IntPtr td, int shadow);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int TextDrawBase_GetShadow(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetOutline(IntPtr td, int outline);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int TextDrawBase_GetOutline(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetBackgroundColour(IntPtr td, uint argb);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern uint TextDrawBase_GetBackgroundColour(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetStyle(IntPtr td, TextDrawStyle style);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern TextDrawStyle TextDrawBase_GetStyle(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetProportional(IntPtr td, bool proportional);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool TextDrawBase_IsProportional(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetSelectable(IntPtr td, bool selectable);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool TextDrawBase_IsSelectable(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetPreviewModel(IntPtr td, int model);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern int TextDrawBase_GetPreviewModel(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetPreviewRotation(IntPtr td, Vector3 rotation);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern Vector3 TextDrawBase_GetPreviewRotation(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetPreviewVehicleColour(IntPtr td, int colour1, int colour2);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static unsafe extern void TextDrawBase_GetPreviewVehicleColour(IntPtr td, int* colour1, int* colour2);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_SetPreviewZoom(IntPtr td, float zoom);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern float TextDrawBase_GetPreviewZoom(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDrawBase_Restream(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]

	public static extern IntPtr TextDraw_CreateText(Vector2 position, string text);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr TextDraw_CreatePreviewModel(Vector2 position, int model);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDraw_ShowForPlayer(IntPtr td, IntPtr player);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDraw_HideForPlayer(IntPtr td, IntPtr player);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool TextDraw_IsShownForPlayer(IntPtr td, IntPtr player);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void TextDraw_SetTextForPlayer(IntPtr td, IntPtr player, string text);


	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_BeginSelection(IntPtr player, uint highlight);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool Player_IsSelecting(IntPtr player);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void Player_EndSelection(IntPtr player);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr PlayerTextDraw_CreateText(IntPtr player, Vector2 position, string text);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern IntPtr PlayerTextDraw_CreatePreviewModel(IntPtr player, Vector2 position, int model);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void PlayerTextDraw_Show(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern void PlayerTextDraw_Hide(IntPtr td);
	[DllImport(NativeInterop.DllName, CallingConvention = NativeInterop.NativeCallingConvetion)]
	public static extern bool PlayerTextDraw_IsShown(IntPtr td);
}
