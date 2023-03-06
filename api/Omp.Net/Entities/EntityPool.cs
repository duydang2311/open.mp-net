namespace Omp.Net.Entities;

public abstract class EntityPool<T> : IEntityPool<T> where T : class
{
	private readonly IEntityFactory<T> factory;
	private readonly IDictionary<int, WeakReference<T>> cache = new Dictionary<int, WeakReference<T>>();

	public EntityPool(IEntityFactory<T> factory)
	{
		this.factory = factory;
	}

	public virtual T Get(int id)
	{
		if (!cache.TryGetValue(id, out var reference))
		{
			var entity = factory.Create(id);
			cache.Add(id, new WeakReference<T>(entity));
			return entity;
		}
		if (!reference.TryGetTarget(out var cachedEntity))
		{
			var entity = factory.Create(id);
			reference.SetTarget(entity);
			return entity;
		}
		return cachedEntity;
	}

	public virtual bool Remove(int id)
	{
		return cache.Remove(id);
	}

	public virtual IReadOnlyCollection<T> GetAll()
	{
		var entities = new LinkedList<T>();
		foreach (var reference in cache.Values)
		{
			if (reference.TryGetTarget(out var entity))
			{
				entities.AddLast(entity);
			}
		}
		return entities;
	}
}
