using System;

namespace _01.OscarsCeremony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double rent = int.Parse(Console.ReadLine());

            double statuettePrice = rent - (rent * 0.3);
            double cateringPrice = statuettePrice - (statuettePrice * 0.15);
            double soundPrice = cateringPrice / 2;

            double sum = statuettePrice + cateringPrice + soundPrice + rent;
            Console.WriteLine($"{sum:f2}");
        }
    }
}
