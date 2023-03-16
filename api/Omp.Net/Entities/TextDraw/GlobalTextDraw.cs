using static Omp.Net.CApi.Natives.TextDrawNative;

namespace Omp.Net.Entities.TextDraw;

public class GlobalTextDraw : BaseTextDraw, IGlobalTextDraw
{
	public GlobalTextDraw(IntPtr nativeHandle) : base(nativeHandle) { }

	public void HideFor(IPlayer player)
	{
		TextDraw_HideForPlayer(NativeHandle, player.NativeHandle);
	}

	public void ShowFor(IPlayer player)
	{
		TextDraw_ShowForPlayer(NativeHandle, player.NativeHandle);
	}

	public bool IsShownFor(IPlayer player)
	{
		return TextDraw_IsShownForPlayer(NativeHandle, player.NativeHandle);
	}
}
