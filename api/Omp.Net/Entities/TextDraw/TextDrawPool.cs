using Omp.Net.Entities.TextDraw;

namespace Omp.Net.Entities;

public class TextDrawPool : ITextDrawPool
{
	private readonly IDictionary<int, WeakReference<ITextDraw>> cache = new Dictionary<int, WeakReference<ITextDraw>>();

	public TextDrawPool() { }

	public virtual bool TryGet(int id, out ITextDraw textDraw)
	{
		if (!cache.TryGetValue(id, out var reference))
		{
			textDraw = default!;
			return false;
		}
		if (!reference.TryGetTarget(out var cachedTextDraw))
		{
			textDraw = default!;
			return false;
		}
		textDraw = cachedTextDraw;
		return true;
	}

	public IReadOnlyCollection<ITextDraw> GetAll()
	{
		var list = new LinkedList<ITextDraw>();
		foreach (var reference in cache.Values)
		{
			if (reference.TryGetTarget(out var textDraw))
			{
				list.AddLast(textDraw);
			}
		}
		return list;
	}

	public virtual bool Remove(int id)
	{
		return cache.Remove(id);
	}
}
