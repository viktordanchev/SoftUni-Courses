using System;

namespace _03.OscarsWeekInCinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string typeHall = Console.ReadLine();
            int ticketCount = int.Parse(Console.ReadLine());

            double price = 0;

            if (movie == "A Star Is Born")
            {
                if (typeHall == "normal")
                {
                    price = 7.50;
                }
                else if (typeHall == "luxury")
                {
                    price = 10.50;
                }
                else if (typeHall == "ultra luxury")
                {
                    price = 13.50;
                }
            }
            else if (movie == "Bohemian Rhapsody")
            {
                if (typeHall == "normal")
                {
                    price = 7.35;
                }
                else if (typeHall == "luxury")
                {
                    price = 9.45;
                }
                else if (typeHall == "ultra luxury")
                {
                    price = 12.75;
                }
            }
            else if (movie == "Green Book")
            {
                if (typeHall == "normal")
                {
                    price = 8.15;
                }
                else if (typeHall == "luxury")
                {
                    price = 10.25;
                }
                else if (typeHall == "ultra luxury")
                {
                    price = 13.25;
                }
            }
            else if (movie == "The Favourite")
            {
                if (typeHall == "normal")
                {
                    price = 8.75;
                }
                else if (typeHall == "luxury")
                {
                    price = 11.55;
                }
                else if (typeHall == "ultra luxury")
                {
                    price = 13.95;
                }
            }

            double profit = ticketCount * price;

            Console.WriteLine($"{movie} -> {profit:f2} lv.");
        }
    }
}
