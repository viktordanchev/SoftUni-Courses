using System;

namespace _11.FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double price = 0;

            switch (dayOfWeek)
            {
                case "Monday":
                case "Tuesday":
                case "Wednesday":
                case "Thursday":
                case "Friday":
                    if (fruit == "banana")
                    {
                        price = 2.50;
                    }
                    else if (fruit == "apple")
                    {
                        price = 1.20;
                    }
                    else if (fruit == "orange")
                    {
                        price = 0.85;
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = 1.45;
                    }
                    else if (fruit == "kiwi")
                    {
                        price = 2.70;
                    }
                    else if (fruit == "pineapple")
                    {
                        price = 5.50;
                    }
                    else if (fruit == "grapes")
                    {
                        price = 3.85;
                    }
                    break;
                case "Saturday":
                case "Sunday":
                    if (fruit == "banana")
                    {
                        price = 2.70;
                    }
                    else if (fruit == "apple")
                    {
                        price = 1.25;
                    }
                    else if (fruit == "orange")
                    {
                        price = 0.90;
                    }
                    else if (fruit == "grapefruit")
                    {
                        price = 1.60;
                    }
                    else if (fruit == "kiwi")
                    {
                        price = 3.00;
                    }
                    else if (fruit == "pineapple")
                    {
                        price = 5.60;
                    }
                    else if (fruit == "grapes")
                    {
                        price = 4.20;
                    }
                    break;
                default:
                    Console.WriteLine("error");
                    break;
            }

            if (price != 0)
            {
                Console.WriteLine($"{quantity * price:f2}");
            }
        }
    }
}
