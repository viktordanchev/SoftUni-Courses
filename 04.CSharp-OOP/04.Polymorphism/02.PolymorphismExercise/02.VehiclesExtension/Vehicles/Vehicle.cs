using System;
using VehiclesExtension.Vehicles.Interfaces;

namespace VehiclesExtension.Vehicles
{
    public abstract class Vehicle : IVehicles
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            //TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                FuelQuantity -= FuelConsumption * distance;
            }
            else
            {
                Console.WriteLine($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters > TankCapacity - FuelQuantity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
