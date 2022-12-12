using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthInCentimeters = int.Parse(Console.ReadLine());
            int widthInCentimeters = int.Parse(Console.ReadLine());
            int heightInCentimeters = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double capacity = lengthInCentimeters * widthInCentimeters * heightInCentimeters;
            double capacityToLiters = capacity / 1000.0;
            double convertToPercent = percent / 100.0;
            double capacityWithoutSand = capacityToLiters * (1 - convertToPercent);

            Console.WriteLine(capacityWithoutSand);
        }
    }
}
