using System;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;

            while (input != "Start")
            {
                double coins = Convert.ToDouble(input);

                if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1 && coins != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                else
                {
                    sum += coins;
                }

                input = Console.ReadLine();
            }

            string product = Console.ReadLine();

            while (product != "End")
            { 
                if (product != "Nuts" && product != "Water" && product != "Crisps" && product != "Soda" && product != "Coke")
                {
                    Console.WriteLine("Invalid product");
                }

                if (sum <= 0)
                {
                    break;
                }

                if (product == "Nuts" && sum >= 2)
                {
                    sum -= 2;
                    Console.WriteLine($"Purchased nuts");
                }
                else if (product == "Water" && sum >= 0.7)
                {
                    sum -= 0.7;
                    Console.WriteLine($"Purchased water");
                }
                else if (product == "Crisps" && sum >= 1.5)
                {
                    sum -= 1.5;
                    Console.WriteLine($"Purchased crisps");
                }
                else if (product == "Soda" && sum >= 0.8)
                {
                    sum -= 0.8;
                    Console.WriteLine($"Purchased soda");
                }
                else if (product == "Coke" && sum >= 1)
                {
                    sum -= 1;
                    Console.WriteLine($"Purchased coke");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
            
                product = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sum:f2}");
        }
    }
}