using System;

namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();

            double ticketForMovie;
            double allTickets = 0;
            double studentTick = 0;
            double standardTick = 0;
            double kidTick = 0;

            while (movie != "Finish")
            {
                double sites = double.Parse(Console.ReadLine());

                double sitesCounter = sites;

                ticketForMovie = 0;

                while (true)
                {
                    if (sitesCounter == 0)
                    {
                        Console.WriteLine($"{movie} - {ticketForMovie / sites * 100:f2}% full.");
                        break;
                    }

                    string ticket = Console.ReadLine();
                    sitesCounter--;

                    if (ticket == "End")
                    {
                        Console.WriteLine($"{movie} - {ticketForMovie / sites * 100:f2}% full.");
                        break;
                    }

                    if (ticket == "student")
                    {
                        studentTick++;
                    }
                    else if (ticket == "standard")
                    {
                        standardTick++;
                    }
                    else if (ticket == "kid")
                    {
                        kidTick++;
                    }

                    ticketForMovie++;
                    allTickets++;
                }

                movie = Console.ReadLine();
            }


            if (movie == "Finish")
            {
                Console.WriteLine($"Total tickets: {allTickets}");
                Console.WriteLine($"{(studentTick / allTickets) * 100:f2}% student tickets.");
                Console.WriteLine($"{(standardTick / allTickets) * 100:f2}% standard tickets.");
                Console.WriteLine($"{(kidTick / allTickets) * 100:f2}% kids tickets.");
            }
        }
    }
}
