using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositAmountPerMonth = int.Parse(Console.ReadLine());
            double interestPercent = double.Parse(Console.ReadLine());

            double interestSum = depositSum * interestPercent / 100;
            double interestPerOneMonth = interestSum / 12;
            double totalSum = depositSum + depositAmountPerMonth * interestPerOneMonth;

            Console.WriteLine(totalSum);
        }
    }
}
