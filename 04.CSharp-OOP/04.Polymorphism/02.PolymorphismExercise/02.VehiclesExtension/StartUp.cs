using System;
using VehiclesExtension.Vehicles;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]));

            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]));

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numOfCommands; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string vehicleType = data[1];
                double value = double.Parse(data[2]);

                Vehicle vehicle;

                switch (vehicleType)
                {
                    case "Car":
                        vehicle = car as Car;
                        if (command == "Drive")
                            vehicle.Drive(value);
                        else
                            vehicle.Refuel(value);
                        break;
                    case "Truck":
                        vehicle = truck as Truck;
                        if (command == "Drive")
                            vehicle.Drive(value);
                        else
                            vehicle.Refuel(value);
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
