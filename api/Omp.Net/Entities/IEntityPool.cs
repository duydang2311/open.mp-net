namespace Omp.Net.Entities;

public interface IEntityPool<T> where T : class
{
	T Create(IntPtr nativeHandle);
	T Create(IntPtr nativeHandle, int id);
	T Get(IntPtr nativeHandle);
	T Get(IntPtr nativeHandle, int id);
	bool Remove(IntPtr nativeHandle);
	IReadOnlyCollection<T> GetAll();
}
