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
            double studentTicket = 0;
            double standardTicket = 0;
            double kidTicket = 0;

            while (movie != "Finish")
            {
                double places = double.Parse(Console.ReadLine());

                double placesCounter = places;

                ticketForMovie = 0;

                while (true)
                {
                    if (placesCounter == 0)
                    {
                        Console.WriteLine($"{movie} - {ticketForMovie / places * 100:f2}% full.");
                        break;
                    }

                    string ticket = Console.ReadLine();
                    placesCounter--;

                    if (ticket == "End")
                    {
                        Console.WriteLine($"{movie} - {ticketForMovie / places * 100:f2}% full.");
                        break;
                    }

                    if (ticket == "student")
                    {
                        studentTicket++;
                    }
                    else if (ticket == "standard")
                    {
                        standardTicket++;
                    }
                    else if (ticket == "kid")
                    {
                        kidTicket++;
                    }

                    ticketForMovie++;
                    allTickets++;
                }

                movie = Console.ReadLine();
            }


            if (movie == "Finish")
            {
                Console.WriteLine($"Total tickets: {allTickets}");
                Console.WriteLine($"{(studentTicket / allTickets) * 100:f2}% student tickets.");
                Console.WriteLine($"{(standardTicket / allTickets) * 100:f2}% standard tickets.");
                Console.WriteLine($"{(kidTicket / allTickets) * 100:f2}% kids tickets.");
            }
        }
    }
}
