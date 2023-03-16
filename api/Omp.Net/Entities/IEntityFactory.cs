namespace Omp.Net.Entities;

public interface IEntityFactory<T> where T : class
{
	T Create(IntPtr nativeHandle, int id);
}
