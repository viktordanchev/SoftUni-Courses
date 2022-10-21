using System;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            int night = days - 1;
            int priceForRoom = 18;
            int priceForApartment = 25;
            int PriceForPresidentApartment = 35;
            double totalSum = 0;

            if (room == "room for one person")
            {
                totalSum = night * priceForRoom;

            }
            else if (room == "apartment")
            {
                totalSum = night * priceForApartment;

                if (night < 10)
                {
                    totalSum *= 0.70;
                }
                else if (night >= 10 && night < 15)
                {
                    totalSum *= 0.65;
                }
                else if (night >= 15)
                {
                    totalSum *= 0.5;
                }
            }
            else if (room == "president apartment")
            {
                totalSum = night * PriceForPresidentApartment;

                if (night < 10)
                {
                    totalSum *= 0.90;
                }
                else if (night >= 10 && night < 15)
                {
                    totalSum *= 0.85;
                }
                else if (night >= 15)
                {
                    totalSum *= 0.80;
                }
            }
            if (rating == "positive")
            {
                totalSum *= 1.25;
            }
            else if (rating == "negative")
            {
                totalSum *= 0.90;
            }
            Console.WriteLine($"{totalSum:f2}");
        }
    }
}
