using Omp.Net.Entities.TextDraw;

namespace Omp.Net.Entities;

public class TextDrawPool : ITextDrawPool
{
	private readonly IDictionary<IntPtr, WeakReference<ITextDraw>> cache = new Dictionary<IntPtr, WeakReference<ITextDraw>>();

	public TextDrawPool() { }

	public virtual bool TryGet(IntPtr nativeHandle, out ITextDraw textDraw)
	{
		if (!cache.TryGetValue(nativeHandle, out var reference))
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

	public virtual bool Remove(IntPtr nativeHandle)
	{
		return cache.Remove(nativeHandle);
	}
}
