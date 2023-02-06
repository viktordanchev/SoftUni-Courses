using System;
using System.Collections.Generic;

namespace _08.CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            GetAllEngines(engines);

            List<Car> cars = new List<Car>();
            GetAllCars(cars, engines);

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }

        private static void GetAllCars(List<Car> cars, List<Engine> engines)
        {
            int numOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCars; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car();

                car.Model = input[0];
                car.Engine = GetEngine(input[1], engines);

                if (input.Length == 3)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        car.Weight = int.Parse(input[2]);
                    }
                    else
                    {
                        car.Color = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                       car.Weight = int.Parse(input[2]);
                       car.Color = input[3];
                    }
                    else
                    {
                        car.Color = input[2];
                        car.Weight = int.Parse(input[3]);
                    }
                }

                cars.Add(car);
            }
        }

        private static Engine GetEngine(string engineType, List<Engine> engines)
        {
            foreach (var engine in engines)
            {
                if (engine.Model == engineType)
                {
                    return engine;
                }
            }

            return null;
        }

        private static void GetAllEngines(List<Engine> engines)
        {
            int numOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfEngines; i++)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new Engine();

                engine.Model = input[0];
                engine.Power = int.Parse(input[1]);

                if (input.Length == 3)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        engine.Displacement = int.Parse(input[2]);
                    }
                    else
                    {
                        engine.Efficiency = input[2];
                    }
                }
                else if (input.Length == 4)
                {
                    if (char.IsDigit(input[2][0]))
                    {
                        engine.Displacement = int.Parse(input[2]);
                        engine.Efficiency = input[3];
                    }
                    else
                    {
                        engine.Efficiency = input[2];
                        engine.Displacement = int.Parse(input[3]);
                    }
                }

                engines.Add(engine);
            }
        }
    }
}