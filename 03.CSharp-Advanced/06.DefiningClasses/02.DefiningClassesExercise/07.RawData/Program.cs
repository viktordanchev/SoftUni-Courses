using System;
using System.Collections.Generic;

namespace _07.RawData
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine(int.Parse(data[1]), int.Parse(data[2]));

                Cargo cargo = new Cargo(data[4], int.Parse(data[3]));

                Tire[] tires= new Tire[4]
                {
                    new Tire(int.Parse(data[6]), double.Parse(data[5])),
                    new Tire(int.Parse(data[8]), double.Parse(data[7])),
                    new Tire(int.Parse(data[10]), double.Parse(data[9])),
                    new Tire(int.Parse(data[12]), double.Parse(data[11]))
                };

                Car car = new Car(data[0], engine, cargo, tires);

                cars.Add(car);
            }

            string cargoType = Console.ReadLine();

            switch (cargoType)
            {
                case "fragile":
                    foreach (var car in cars) 
                    {
                        if (car.Cargo.Type == "fragile")
                        {
                            foreach (var tire in car.Tires)
                            {
                                if (tire.Pressure < 1)
                                {
                                    Console.WriteLine(car.Model);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case "flammable":
                    foreach (var car in cars)
                    {
                        if (car.Cargo.Type == "flammable" && car.Engine.Power > 250)
                        {
                            Console.WriteLine(car.Model);
                        }
                    }
                    break;
            }
        }
    }
}