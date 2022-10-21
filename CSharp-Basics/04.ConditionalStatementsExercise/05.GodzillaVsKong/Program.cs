using System;

namespace _05.GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budgetForMovie = double.Parse(Console.ReadLine());
            int numberOfExtras = int.Parse(Console.ReadLine());
            double priceForClothesOfOneExtra = double.Parse(Console.ReadLine());

            double priceForDecor = budgetForMovie * 0.10;
            double totalPriceForClothes = numberOfExtras * priceForClothesOfOneExtra;

            if (numberOfExtras > 150)
            {
                totalPriceForClothes = totalPriceForClothes - totalPriceForClothes * 0.10;
            }

            double totalPriceForAll = totalPriceForClothes + priceForDecor;

            if (totalPriceForAll <= budgetForMovie)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budgetForMovie - (priceForDecor + totalPriceForClothes):f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {(priceForDecor + totalPriceForClothes) - budgetForMovie:f2} leva more.");
            }
        }
    }
}
