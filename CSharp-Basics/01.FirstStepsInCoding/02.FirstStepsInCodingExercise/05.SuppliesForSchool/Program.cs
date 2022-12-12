using System;

namespace _05.SuppliesForSchool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPenPacks = int.Parse(Console.ReadLine());
            int numberOfMarkersPacks = int.Parse(Console.ReadLine());
            int litersOfBoardCleaner = int.Parse(Console.ReadLine());
            int discount = int.Parse(Console.ReadLine());

            double priceForPenPack = numberOfPenPacks * 5.80;
            double priceForMarkersPack = numberOfMarkersPacks * 7.20;
            double priceForLiterOfBoardCleaner = litersOfBoardCleaner * 1.20;
            double totalSumWithoutDiscount = priceForPenPack + priceForMarkersPack + priceForLiterOfBoardCleaner;
            double discountPercent = discount / 100.0;
            double totalSumWithDiscound = totalSumWithoutDiscount * discountPercent;
            double totalSum = totalSumWithoutDiscount - totalSumWithDiscound;

            Console.WriteLine(totalSum);
        }
    }
}
