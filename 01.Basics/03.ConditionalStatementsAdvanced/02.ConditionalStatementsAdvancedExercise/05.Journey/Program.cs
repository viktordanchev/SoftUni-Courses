using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string destination = "";
            double sum = 0;
            string typeOfVacantion = "";


            if (budget <= 100)
            {
                destination = "Bulgaria";
            }
            if (destination == "Bulgaria")
            {
                if (season == "summer")
                {
                    sum = budget / 100 * 30;
                }
                if (season == "summer")
                {
                    typeOfVacantion = "Camp";
                }
                if (season == "winter")
                {
                    sum = budget / 100 * 70;
                }
                if (season == "winter")
                {
                    typeOfVacantion = "Hotel";
                }
            }
            if (budget > 100 && budget <= 1000)
            {
                destination = "Balkans";
            }
            if (destination == "Balkans")
            {
                if (season == "summer")
                {
                    sum = budget / 100 * 40;
                }
                if (season == "summer")
                {
                    typeOfVacantion = "Camp";
                }
                if (season == "winter")
                {
                    sum = budget / 100 * 80;
                }
                if (season == "winter")
                {
                    typeOfVacantion = "Hotel";
                }
            }
            if (budget > 1000)
            {
                destination = "Europe";
            }
            if (destination == "Europe")
            {
                if (season == "summer" || season == "winter")
                {
                    sum = budget / 100 * 90;
                }
                if (destination == "Europe")
                {
                    typeOfVacantion = "Hotel";
                }
            }
            Console.WriteLine($"Somewhere in {destination}");
            Console.WriteLine($"{typeOfVacantion} - {sum:f2}");
        }
    }
}
