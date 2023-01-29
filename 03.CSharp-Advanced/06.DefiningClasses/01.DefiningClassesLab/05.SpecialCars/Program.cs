using System;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tiresList = new List<Tire[]>();
            List<Engine> enginesList = new List<Engine>();
            List<Car> carsList = new List<Car>();

            string command = Console.ReadLine();

            while (command != "No more tires")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] tires = new Tire[4]
                {
                    new Tire(int.Parse(data[0]), double.Parse(data[1])),
                    new Tire(int.Parse(data[2]), double.Parse(data[3])),
                    new Tire(int.Parse(data[4]), double.Parse(data[5])),
                    new Tire(int.Parse(data[6]), double.Parse(data[7]))
                };

                tiresList.Add(tires);

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Engines done")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                enginesList.Add(new Engine(int.Parse(data[0]), double.Parse(data[1])));

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "Show special")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car car = new Car(data[0], data[1], int.Parse(data[2]), double.Parse(data[3]), double.Parse(data[4]), int.Parse(data[5]), int.Parse(data[6]));

                carsList.Add(car);

                command = Console.ReadLine();
            }

            foreach (var car in carsList)
            {
                if (car.Year >= 2017)
                {
                    if (enginesList[car.EngineIndex].HorsePower > 330)
                    {
                        double sum = 0;

                        sum += tiresList[car.TiresIndex][0].Pressure;
                        sum += tiresList[car.TiresIndex][1].Pressure;
                        sum += tiresList[car.TiresIndex][2].Pressure;
                        sum += tiresList[car.TiresIndex][3].Pressure;

                        if (sum >= 9 && sum <= 10)
                        {
                            car.Drive(0.2);

                            Console.WriteLine($"Make: {car.Make}");
                            Console.WriteLine($"Model: {car.Model}");
                            Console.WriteLine($"Year: {car.Year}");
                            Console.WriteLine($"HorsePowers: {enginesList[car.EngineIndex].HorsePower}");
                            Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                        }
                    }
                }
            }
        }
    }
}