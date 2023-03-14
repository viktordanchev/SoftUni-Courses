﻿using System;
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

        public abstract void Refuel(double liters);

        public override string ToString()
        {
            return $"{GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
