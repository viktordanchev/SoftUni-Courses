using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = Console.ReadLine();
            car.Model = Console.ReadLine();
            car.Year = int.Parse(Console.ReadLine());

            Console.WriteLine($"Make: {car.Make}");
            Console.WriteLine($"Model: {car.Model}");
            Console.WriteLine($"Year: {car.Year}");
        }
    }
}

