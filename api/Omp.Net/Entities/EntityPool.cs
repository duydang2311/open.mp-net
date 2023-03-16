namespace Omp.Net.Entities;

public abstract class EntityPool<T> : IEntityPool<T> where T : class
{
	private readonly IEntityFactory<T> factory;
	private readonly IDictionary<IntPtr, WeakReference<T>> cache = new Dictionary<IntPtr, WeakReference<T>>();

	public EntityPool(IEntityFactory<T> factory)
	{
		this.factory = factory;
	}

	public virtual T Create(IntPtr nativeHandle, int id)
	{
		return factory.Create(nativeHandle, id);
	}

	public virtual T Get(IntPtr nativeHandle, int id)
	{
		if (!cache.TryGetValue(nativeHandle, out var reference))
		{
			var entity = factory.Create(nativeHandle, id);
			cache.Add(nativeHandle, new WeakReference<T>(entity));
			return entity;
		}
		if (!reference.TryGetTarget(out var cachedEntity))
		{
			var entity = factory.Create(nativeHandle, id);
			reference.SetTarget(entity);
			return entity;
		}
		return cachedEntity;
	}

	public virtual bool Remove(IntPtr nativeHandle)
	{
		return cache.Remove(nativeHandle);
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
