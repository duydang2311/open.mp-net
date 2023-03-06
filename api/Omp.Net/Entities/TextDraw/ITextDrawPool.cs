namespace Omp.Net.Entities.TextDraw;

public interface ITextDrawPool
{
	bool TryGet(int id, out ITextDraw textDraw);
	IReadOnlyCollection<ITextDraw> GetAll();
	bool Remove(int id);
}
