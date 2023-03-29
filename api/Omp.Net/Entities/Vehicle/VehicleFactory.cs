namespace Omp.Net.Entities.Vehicle;

public class VehicleFactory : IEntityFactory<IVehicle>
{
	public IVehicle Create(IntPtr nativeHandle, int id)
	{
		return new BaseVehicle(nativeHandle, id);
	}
}
