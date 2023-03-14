using System;

namespace Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            FuelConsumption += 1.6;
        }

        public override void Drive(double distance)
        {
            if (FuelQuantity >= FuelConsumption * distance)
            {
                Console.WriteLine($"Truck travelled {distance} km");
                FuelQuantity -= FuelConsumption * distance;
            }
            else
            {
                Console.WriteLine("Truck needs refueling");
            }
        }

        public override void Refuel(double liters)
        {
            FuelQuantity += liters * 0.95;
        }
    }
}
