using System;

namespace _02.PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());

            double poundsToUsd = pounds * 1.31;

            Console.WriteLine($"{poundsToUsd:f3}");
        }

    }
}

