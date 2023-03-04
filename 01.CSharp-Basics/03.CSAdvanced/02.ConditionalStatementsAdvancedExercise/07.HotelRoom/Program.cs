using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nigth = int.Parse(Console.ReadLine());
            double priceStudio = 0.0;
            double priceApartment = 0.0;
            if (month == "May" || month == "October")
            {
                priceStudio = nigth * 50;
                if (nigth > 14)
                {
                    priceStudio = priceStudio - priceStudio * 0.3;
                }
                else if (nigth > 7)
                {
                    priceStudio = priceStudio - priceStudio * 0.05;
                }
                priceApartment = nigth * 65;
                if (nigth > 14)
                {
                    priceApartment = priceApartment - priceApartment * 0.1;
                }
                Console.WriteLine($"Apartment: {priceApartment:f2} lv.");
                Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            }
            else if (month == "June" || month == "September")
            {
                priceStudio = nigth * 75.2;
                if (nigth > 14)
                {
                    priceStudio = priceStudio - priceStudio * 0.2;
                }
                priceApartment = nigth * 68.7;
                if (nigth > 14)
                {
                    priceApartment = priceApartment - priceApartment * 0.1;
                }
                Console.WriteLine($"Apartment: {priceApartment:f2} lv.");
                Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            }
            else if (month == "July" || month == "August")
            {
                priceStudio = nigth * 76;
                priceApartment = nigth * 77;
                if (nigth > 14)
                {
                    priceApartment = priceApartment - priceApartment * 0.1;
                }
                Console.WriteLine($"Apartment: {priceApartment:f2} lv.");
                Console.WriteLine($"Studio: {priceStudio:f2} lv.");
            }
        }
    }
}
