using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace _06.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(' ');
            double carsHorsepower = 0;
            double trucksHorsepower = 0;
            Catalogue catalogue = new Catalogue();

            while (input[0] != "End")
            {
                if (input[0] == "car")
                {
                    Car car = new Car
                    {
                        Type = input[0],
                        Model = input[1],
                        Color = input[2],
                        HorsePower = int.Parse(input[3])
                    };

                    carsHorsepower += car.HorsePower;
                    catalogue.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck
                    {
                        Type = input[0],
                        Model = input[1],
                        Color = input[2],
                        HorsePower = int.Parse(input[3])
                    };

                    trucksHorsepower += truck.HorsePower;
                    catalogue.Trucks.Add(truck);
                }

                input = Console.ReadLine().Split(' ');
            }

            double averageHpCars = 0;
            double averageHpTrucks = 0;
            if (catalogue.Cars.Count > 0)
            {
                averageHpCars = carsHorsepower / catalogue.Cars.Count;
            }

            if (catalogue.Trucks.Count > 0)
            {
                averageHpTrucks = trucksHorsepower / catalogue.Trucks.Count;
            }
            
            string vehicle = Console.ReadLine();
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();

            while (vehicle != "Close the Catalogue")
            {
                foreach (Car car in catalogue.Cars)
                {
                    if (vehicle == car.Model)
                    {
                        Car currCar = new Car()
                        {
                            Model = car.Model,
                            Color = car.Color,
                            HorsePower = car.HorsePower
                        };

                        cars.Add(currCar);
                        break;
                    }
                }

                foreach (Truck truck in catalogue.Trucks)
                {
                    if (vehicle == truck.Model)
                    {
                        Truck currTruck = new Truck()
                        {
                            Model = truck.Model,
                            Color = truck.Color,
                            HorsePower = truck.HorsePower
                        };

                        trucks.Add(currTruck);
                        break;
                    }
                }

                vehicle = Console.ReadLine();
            }

            Print(cars, trucks, averageHpCars, averageHpTrucks);
        }

        static void Print(List<Car> cars, List<Truck> trucks, double averageHpCars, double averageHpTrucks)
        {
            if (cars.Count > 0)
            {
                foreach (Car car in cars)
                {
                    Console.WriteLine($"Type: Car");
                    Console.WriteLine($"Model: {car.Model}");
                    Console.WriteLine($"Color: {car.Color}");
                    Console.WriteLine($"Horsepower: {car.HorsePower}");
                }
            }

            if (trucks.Count > 0)
            {
                foreach (Truck truck in trucks)
                {
                    Console.WriteLine($"Type: Truck");
                    Console.WriteLine($"Model: {truck.Model}");
                    Console.WriteLine($"Color: {truck.Color}");
                    Console.WriteLine($"Horsepower: {truck.HorsePower}");
                }
            }

            Console.WriteLine($"Cars have average horsepower of: {averageHpCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHpTrucks:f2}.");
        }
    }

    class Car
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    class Truck
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }
    }

    class Catalogue
    {
        public Catalogue()
        {
            this.Cars = new List<Car>();
            this.Trucks = new List<Truck>();
        }

        public List<Car> Cars { get; set; }
        public List<Truck> Trucks { get; set; }
    }
}
