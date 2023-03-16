using System;
using VehiclesExtension.Vehicles;

namespace VehiclesExtension
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] carInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));

            string[] truckInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            
            string[] busInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            
            int numOfCommands = int.Parse(Console.ReadLine());
            
            for (int i = 1; i <= numOfCommands; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string vehicleType = data[1];
                double value = double.Parse(data[2]);

                try
                {
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
                        case "Bus":
                            if (command == "Drive")
                                bus.Drive(value);
                            else if (command == "DriveEmpty")
                            {
                                Bus currBus = bus as Bus;
                                currBus.DriveEmpty(value);
                            }
                            else
                                bus.Refuel(value);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
