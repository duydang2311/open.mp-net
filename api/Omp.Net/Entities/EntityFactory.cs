namespace Omp.Net.Entities;

public abstract class EntityFactory<T> : IEntityFactory<T> where T : class
{
	public abstract T Create(int id);
}
