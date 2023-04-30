using System;
using VehiclesExtension.Vehicles.Interfaces;

namespace VehiclesExtension.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private double tankCapacity;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
        }

        public double FuelQuantity { get; protected set; }
        public double FuelConsumption { get; protected set; }
        public double TankCapacity
        {
            get => tankCapacity;
            private set
            {
                if (FuelQuantity > value)
                {
                    FuelQuantity = 0;
                }

                tankCapacity = value;
            }
        }

        public void Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                Console.WriteLine($"{GetType().Name} travelled {distance} km");
                FuelQuantity -= FuelConsumption * distance;
            }
            else
            {
                throw new ArgumentException($"{GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            else if (liters > TankCapacity - FuelQuantity)
            {
                throw new ArgumentException($"Cannot fit {liters} fuel in the tank");
            }
            else if (GetType().Name == "Car" || GetType().Name == "Bus")
            {
                FuelQuantity += liters;
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
