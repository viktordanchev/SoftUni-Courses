using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceForExcursion = double.Parse(Console.ReadLine());
            int numOfPuzzles = int.Parse(Console.ReadLine());
            int numOfDolls = int.Parse(Console.ReadLine());
            int numOfBears = int.Parse(Console.ReadLine());
            int numOfMinions = int.Parse(Console.ReadLine());
            int numOfCars = int.Parse(Console.ReadLine());

            double sum = numOfPuzzles * 2.60 + numOfDolls * 3 + numOfBears * 4.10 + numOfMinions * 8.20 + numOfCars * 2;
            int numOfToys = numOfPuzzles + numOfDolls + numOfBears + numOfMinions + numOfCars;

            if (numOfToys >= 50)
            {
                sum = sum - sum * 0.25;
            }

            sum = sum - sum * 0.10;

            if (sum >= priceForExcursion)
            {
                Console.WriteLine($"Yes! {sum - priceForExcursion:f2} lv left.");

            }
            else
            {
                Console.WriteLine($"Not enough money! {priceForExcursion - sum:f2} lv needed.");
            }
        }
    }
}
