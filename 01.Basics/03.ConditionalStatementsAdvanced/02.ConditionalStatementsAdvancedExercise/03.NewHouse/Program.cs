using System;

namespace _03.NewHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flowers = Console.ReadLine();
            int numFlowers = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalPrice = 0;
            double price = 0;

            if (flowers == "Roses")
            {
                price = 5;
                totalPrice = numFlowers * price;

                if (numFlowers > 80)
                {
                    totalPrice = totalPrice - (totalPrice * 0.1);
                }
            }
            else if (flowers == "Dahlias")
            {
                price = 3.80;
                totalPrice = numFlowers * price;

                if (numFlowers > 90)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
            }
            else if (flowers == "Tulips")
            {
                price = 2.80;
                totalPrice = numFlowers * price;

                if (numFlowers > 80)
                {
                    totalPrice = totalPrice - (totalPrice * 0.15);
                }
            }
            else if (flowers == "Narcissus")
            {
                price = 3;
                totalPrice = numFlowers * price;

                if (numFlowers < 120)
                {
                    totalPrice = totalPrice + (totalPrice * 0.15);
                }
            }
            else if (flowers == "Gladiolus")
            {
                price = 2.50;
                totalPrice = numFlowers * price;

                if (numFlowers < 80)
                {
                    totalPrice = totalPrice + (totalPrice * 0.20);
                }
            }



            if (budget >= totalPrice)
            {
                Console.WriteLine($"Hey, you have a great garden with {numFlowers} {flowers} and {budget - totalPrice:f2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {totalPrice - budget:f2} leva more.");
            }
        }
    }
}
