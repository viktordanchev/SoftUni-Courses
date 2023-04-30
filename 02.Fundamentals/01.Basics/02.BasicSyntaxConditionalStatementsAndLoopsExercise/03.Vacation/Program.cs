using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double countOfPeoples = double.Parse(Console.ReadLine());
            string typeGroup = Console.ReadLine();
            string dayOfTheWeek = Console.ReadLine();
            double price = 0;
            double totalPrice;

            if (typeGroup == "Students")
            {
                if (dayOfTheWeek == "Friday")
                {
                    price = 8.45;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    price = 9.80;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    price = 10.46;
                }
            }
            else if (typeGroup == "Business")
            {
                if (dayOfTheWeek == "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    price = 16;
                }
            }
            else if (typeGroup == "Regular")
            {
                if (dayOfTheWeek == "Friday")
                {
                    price = 15;
                }
                else if (dayOfTheWeek == "Saturday")
                {
                    price = 20;
                }
                else if (dayOfTheWeek == "Sunday")
                {
                    price = 22.50;
                }
            }

            if (typeGroup == "Business" && countOfPeoples >= 100)
            {
                countOfPeoples -= 10;
            }

            totalPrice = price * countOfPeoples;

            if (typeGroup == "Students" && countOfPeoples >= 30)
            {
                totalPrice = totalPrice - ((totalPrice / 100) * 15);
            }
            else if (typeGroup == "Regular" && countOfPeoples >= 10 && countOfPeoples <= 20)
            {
                totalPrice = totalPrice - ((totalPrice / 100) * 5);
            }

            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}