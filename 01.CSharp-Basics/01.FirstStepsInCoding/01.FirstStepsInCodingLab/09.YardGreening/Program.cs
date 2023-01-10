using System;

namespace _09.YardGreening
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double squareMetersForLandscaping = double.Parse(Console.ReadLine());
            double endPrice = squareMetersForLandscaping * 7.61;
            double discountFromEndPrice = endPrice * 0.18;
            double finalPrice = endPrice - discountFromEndPrice;
            Console.WriteLine($"The final price is: {finalPrice} lv.");
            Console.WriteLine($"The discount is: {discountFromEndPrice} lv.");
        }
    }
}
