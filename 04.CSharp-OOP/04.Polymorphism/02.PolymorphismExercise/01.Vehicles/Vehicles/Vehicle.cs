using Vehicles.Vehicles.Interfaces;

namespace Vehicles.Vehicles
{
    public abstract class Vehicle : IVehicles
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public abstract void Drive(double distance);
        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
