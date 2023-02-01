using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int numOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfEngines; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (data.Length == 2)
                {
                    Engine engine = new Engine(data[0], int.Parse(data[1]));
                    engines.Add(engine);
                }
                else if (data.Length == 3)
                {
                    Engine engine = new Engine(data[0], int.Parse(data[1]), int.Parse(data[2]));
                    engines.Add(engine);
                }
                else
                {
                    Engine engine = new Engine(data[0], int.Parse(data[1]), int.Parse(data[2]), data[3]);
                    engines.Add(engine);
                }
            }

            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = null;

                foreach (var currEngine in engines)
                {
                    if (currEngine.Model == data[1])
                    {
                        engine = currEngine;
                        break;
                    }
                }

                if (data.Length == 2)
                {
                    Car car = new Car(data[0], engine);
                    cars.Add(car);
                }
                else if (data.Length == 3)
                {
                    Car car = new Car(data[0], engine, int.Parse(data[2]));
                    cars.Add(car);
                }
                else
                {
                    Car car = new Car(data[0], engine, int.Parse(data[2]), data[3]);
                    cars.Add(car);
                }
            }
        }
    }
}
