using System;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fisherman = int.Parse(Console.ReadLine());

            double rentForBoat = 0;

            if (season == "Spring")
            {
                rentForBoat = 3000;

                if (fisherman <= 6)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.1);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.15);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }
                }
                else if (fisherman > 12)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.25);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }
                }


            }
            else if (season == "Summer")
            {
                rentForBoat = 4200;

                if (fisherman <= 6)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.1);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.15);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }
                }
                else if (fisherman > 12)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.25);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }

                }


            }
            else if (season == "Autumn")
            {
                rentForBoat = 4200;

                if (fisherman <= 6)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.1);
                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.15);
                }
                else if (fisherman > 12)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.25);
                }
            }
            else if (season == "Winter")
            {
                rentForBoat = 2600;

                if (fisherman <= 6)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.1);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }

                }
                else if (fisherman >= 7 && fisherman <= 11)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.15);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }
                }
                else if (fisherman > 12)
                {
                    rentForBoat = rentForBoat - (rentForBoat * 0.25);

                    if (fisherman % 2 == 0)
                    {
                        rentForBoat = rentForBoat - (rentForBoat * 0.05);
                    }
                }
            }

            if (budget >= rentForBoat)
            {
                Console.WriteLine($"Yes! You have {budget - rentForBoat:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {rentForBoat - budget:f2} leva.");
            }
        }
    }
}
