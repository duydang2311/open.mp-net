namespace Omp.Net.Entities.Vehicle;

public class VehiclePool : EntityPool<IVehicle>
{
	public VehiclePool(IEntityFactory<IVehicle> factory) : base(factory) { }
}
