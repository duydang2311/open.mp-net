using System.Numerics;
using Omp.Net.Entities.TextDraw;

namespace Omp.Net.Entities;

public class TextDrawPool : ITextDrawPool
{
	private readonly IDictionary<IntPtr, WeakReference<ITextDraw>> cache = new Dictionary<IntPtr, WeakReference<ITextDraw>>();
	private readonly ITextDrawFactory factory;

	public TextDrawPool(ITextDrawFactory factory)
	{
		this.factory = factory;
	}

	public ITextDraw Create(Vector2 position, string text)
	{
		var td = factory.Create(position, text);
		cache.Add(td.NativeHandle, new WeakReference<ITextDraw>(td));
		return td;
	}

	public ITextDraw Create(Vector2 position, int model)
	{
		var td = factory.Create(position, model);
		cache.Add(td.NativeHandle, new WeakReference<ITextDraw>(td));
		return td;
	}

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
