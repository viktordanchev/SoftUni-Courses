namespace Vehicles.Vehicles.Interfaces
{
    public interface IVehicles
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        void Drive(double distance);
        void Refuel(double liters);
    }
}
