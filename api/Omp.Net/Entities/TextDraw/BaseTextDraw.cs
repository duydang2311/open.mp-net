using System.Drawing;
using System.Numerics;
using Omp.Net.Shared.Enums;

namespace Omp.Net.Entities.TextDraw;

public abstract class BaseTextDraw : ITextDraw
{
	private readonly int id;

	public BaseTextDraw(int id)
	{
		this.id = id;
	}

	public int Id => id;
	public abstract Vector2 Position { get; set; }
	public abstract int Alignment { get; set; }
	public abstract Color Color { get; set; }
	public abstract Color BoxColor { get; set; }
	public abstract Color BackgroundColor { get; set; }
	public abstract TextDrawStyle Style { get; set; }
	public abstract Vector2 LetterSize { get; set; }
	public abstract int Outline { get; set; }
	public abstract int PreviewModel { get; set; }
	public abstract Vector3 PreviewRotation { get; set; }
	public abstract float PreviewZoom { get; set; }
	public abstract int PreviewVehiclePrimaryColor { get; set; }
	public abstract int PreviewVehicleSecondaryColor { get; set; }
	public abstract bool IsSelectable { get; set; }
	public abstract int Shadow { get; set; }
	public abstract bool IsProportional { get; set; }
	public abstract string Text { get; set; }
	public abstract Vector2 TextSize { get; set; }
	public abstract bool UseBox { get; set; }
}
