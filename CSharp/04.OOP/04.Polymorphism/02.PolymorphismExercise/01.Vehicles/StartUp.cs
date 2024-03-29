﻿using System;
using Vehicles.Vehicles;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numOfCommands; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string vehicleType = data[1];
                double value = double.Parse(data[2]);

                switch (vehicleType)
                {
                    case "Car":
                        if (command == "Drive")
                            car.Drive(value);
                        else
                            car.Refuel(value);
                        break;
                    case "Truck":
                        if (command == "Drive")
                            truck.Drive(value);
                        else
                            truck.Refuel(value);
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
