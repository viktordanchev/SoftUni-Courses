using System;
using System.Collections.Generic;

namespace _06.SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();   

            int numOfCars = int.Parse(Console.ReadLine());

            int chekcs = 0;
            for (int i = 0; i < numOfCars; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var currCar in cars)
                {
                    if (currCar.Model == data[0])
                    {
                        chekcs++;
                    }
                }

                if (chekcs == 0)
                {
                    Car car = new Car();

                    car.Model = data[0];
                    car.FuelAmount = double.Parse(data[1]);
                    car.FuelConsumptionPerKilometer = double.Parse(data[2]);

                    cars.Add(car);
                }

                chekcs = 0;
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                foreach (var car in cars)
                {
                    if (data[1] == car.Model)
                    {
                        car.CanMoveThatDistance(int.Parse(data[2]));
                    }
                }

                command = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}