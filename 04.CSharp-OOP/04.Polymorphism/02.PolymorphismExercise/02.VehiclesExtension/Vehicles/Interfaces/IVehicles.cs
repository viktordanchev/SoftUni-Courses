namespace VehiclesExtension.Vehicles.Interfaces
{
    public interface IVehicles
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        double TankCapacity { get; }
        void Drive(double distance);
        void Refuel(double liters);
    }
}
