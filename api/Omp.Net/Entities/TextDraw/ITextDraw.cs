using System.Drawing;
using System.Numerics;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Entities.TextDraw;

public interface ITextDraw
{
	IntPtr NativeHandle { get; }
	int Id { get; }
	Vector2 Position { get; set; }
	TextDrawAlignment Alignment { get; set; }
	Color Color { get; set; }
	Color BoxColor { get; set; }
	Color BackgroundColor { get; set; }
	TextDrawStyle Style { get; set; }
	Vector2 LetterSize { get; set; }
	int Outline { get; set; }
	int PreviewModel { get; set; }
	Vector3 PreviewRotation { get; set; }
	float PreviewZoom { get; set; }
	bool IsSelectable { get; set; }
	int Shadow { get; set; }
	bool IsProportional { get; set; }
	string Text { get; set; }
	Vector2 TextSize { get; set; }
	bool UseBox { get; set; }

	void GetPreviewVehicleColor(out int primaryColor, out int secondaryColor);
	void SetPreviewVehicleColor(int primaryColor, int secondaryColor);
	void Restream();
}
