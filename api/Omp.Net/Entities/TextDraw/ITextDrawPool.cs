using System.Numerics;

namespace Omp.Net.Entities.TextDraw;

public interface ITextDrawPool
{
	ITextDraw Create(Vector2 position, string text);
	ITextDraw Create(Vector2 position, int model);
	bool TryGet(IntPtr nativeHandle, out ITextDraw textDraw);
	IReadOnlyCollection<ITextDraw> GetAll();
	bool Remove(IntPtr nativeHandle);
}
