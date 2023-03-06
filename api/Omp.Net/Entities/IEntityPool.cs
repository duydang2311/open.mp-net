namespace Omp.Net.Entities;

public interface IEntityPool<T> where T : class
{
	T Get(int id);
	bool Remove(int id);
	IReadOnlyCollection<T> GetAll();
}
