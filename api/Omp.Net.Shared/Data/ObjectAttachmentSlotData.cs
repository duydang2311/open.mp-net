using System.Drawing;
using System.Numerics;

namespace Omp.Net.Shared.Data;

public readonly record struct ObjectAttachmentSlotData
{
	public readonly int Model { get; init; }
	public readonly int Bone { get; init; }
	public readonly Vector3 Offset { get; init; }
	public readonly Vector3 Rotation { get; init; }
	public readonly Vector3 Scale { get; init; }
	public readonly Color Color1 { get; init; }
	public readonly Color Color2 { get; init; }

	public readonly override string ToString()
	{
		return $"({Model}, {Bone}, {Offset}, {Rotation}, {Scale}, {Color1}, {Color2})";
	}
};
