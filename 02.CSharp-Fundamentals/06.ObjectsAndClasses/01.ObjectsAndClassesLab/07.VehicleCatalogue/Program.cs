using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace _07.VehicleCatalogue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split('/');
            Catalogue catalogue = new Catalogue();

            while (input[0] != "end")
            {
                if (input[0] == "Car")
                {
                    Car car = new Car
                    {
                        Brand = input[1],
                        Model = input[2],
                        HorsePower = input[3]
                    };

                    catalogue.Cars.Add(car);
                }
                else
                {
                    Truck truck = new Truck
                    {
                        Brand = input[1],
                        Model = input[2],
                        Weight = input[3]
                    };

                    catalogue.Trucks.Add(truck);
                }

                input = Console.ReadLine().Split('/');
            }

            if (catalogue.Cars.Count > 0)
            {
                List<Car> orderedCatalogue = catalogue.Cars.OrderBy(c => c.Brand).ToList();

                Console.WriteLine("Cars:");
                foreach (Car car in orderedCatalogue)
                {
                    Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
                }
            }

            if (catalogue.Trucks.Count > 0)
            {
                List<Truck> orderedCatalogue = catalogue.Trucks.OrderBy(c => c.Brand).ToList();

                Console.WriteLine("Trucks:");
                foreach (Truck truck in orderedCatalogue)
                {
                    Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
                }
            }
        }
    }

    class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string HorsePower { get; set; }
    }

    class Truck
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Weight { get; set; }
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
