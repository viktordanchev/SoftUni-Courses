using System;

namespace Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 0.9;
        }

        public override void Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                Console.WriteLine($"Car travelled {distance} km");
                FuelQuantity -= FuelConsumption * distance;
            }
            else
            {
                Console.WriteLine("Car needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters;
        }
    }
}
