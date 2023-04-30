using System;

namespace _02.GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int countOfPeople = int.Parse(Console.ReadLine());
            double priceForClothesPerPerson = double.Parse(Console.ReadLine());

            double decor = budget * 0.10;

            if (countOfPeople >= 150)
            {
                priceForClothesPerPerson = priceForClothesPerPerson - (priceForClothesPerPerson * 0.10);
            }

            double totalPriceForClothes = countOfPeople * priceForClothesPerPerson;

            if (totalPriceForClothes + decor > budget)
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(totalPriceForClothes + decor) - budget:f2} leva more.");
            }
            else
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - (totalPriceForClothes + decor):f2} leva left.");
            }
        }
    }
}
