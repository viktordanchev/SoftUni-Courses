using System;

namespace VehiclesExtension.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            FuelConsumption += 0.9;
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
