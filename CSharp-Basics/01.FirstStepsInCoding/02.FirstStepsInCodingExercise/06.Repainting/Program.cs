using System;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int requiredNylon = int.Parse(Console.ReadLine());
            int requiredDye = int.Parse(Console.ReadLine());
            int requiredThinner = int.Parse(Console.ReadLine());
            int requiredHours = int.Parse(Console.ReadLine());

            double nylonPrice = (requiredNylon + 2) * 1.50;
            double percentForDye = requiredDye * (10 / 100.0);
            double priceForDye = (requiredDye + percentForDye) * 14.50;
            int priceForThinner = requiredThinner * 5;
            double totalPriceWithoutPainter = nylonPrice + priceForDye + priceForThinner + 0.40;
            double percentOfMoneyForPainters = totalPriceWithoutPainter * (30 / 100.0);
            double priceForPainters = percentOfMoneyForPainters * requiredHours;
            double totalSum = totalPriceWithoutPainter + priceForPainters;
            Console.WriteLine(totalSum);
        }
    }
}
