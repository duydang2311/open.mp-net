using static Omp.Net.CApi.Natives.TextDrawNative;

namespace Omp.Net.Entities.TextDraw;

public partial class PlayerTextDraw : BaseTextDraw, IPlayerTextDraw
{
	public IPlayer Player { get; }

	public bool IsShown => PlayerTextDraw_IsShown(NativeHandle);

	public PlayerTextDraw(IPlayer player, IntPtr nativeHandle) : base(nativeHandle)
	{
		Player = player;
	}

	public void Hide()
	{
		PlayerTextDraw_Hide(NativeHandle);
	}

	public void Show()
	{
		PlayerTextDraw_Show(NativeHandle);
	}
}
