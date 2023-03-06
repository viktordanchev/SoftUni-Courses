using System;

namespace _11.Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ordersCount = int.Parse(Console.ReadLine());

            double total = 0;

            for (int i = 1; i <= ordersCount; i++)
            {
                double capsulePrice = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCount = int.Parse(Console.ReadLine());

                double result = (days * capsulesCount) * capsulePrice;
                total += result;

                Console.WriteLine($"The price for the coffee is: ${result:f2}");
            }

            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
