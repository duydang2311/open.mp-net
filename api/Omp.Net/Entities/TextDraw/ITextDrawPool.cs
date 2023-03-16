namespace Omp.Net.Entities.TextDraw;

public interface ITextDrawPool
{
	bool TryGet(IntPtr nativeHandle, out ITextDraw textDraw);
	IReadOnlyCollection<ITextDraw> GetAll();
	bool Remove(IntPtr nativeHandle);
}
