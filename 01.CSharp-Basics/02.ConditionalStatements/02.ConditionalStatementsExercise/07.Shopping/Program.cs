using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int videoCards = int.Parse(Console.ReadLine());
            int processors = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double priceForVideo = videoCards * 250;
            double priceForProcessors = (priceForVideo * 0.35) * processors;
            double priceForRam = (priceForVideo * 0.10) * ram;
            double sumOfAll = priceForVideo + priceForProcessors + priceForRam;

            if (videoCards > processors)
            {
                sumOfAll = sumOfAll - (sumOfAll * 0.15);
            }

            if (budget >= sumOfAll)
            {
                Console.WriteLine($"You have {budget - sumOfAll:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {sumOfAll - budget:f2} leva more!");
            }
        }
    }
}
