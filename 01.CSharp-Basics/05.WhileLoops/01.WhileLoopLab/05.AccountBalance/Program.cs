using System;

namespace _05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double sum = 0;

            while (input != "NoMoreMoney")
            {
                double fee = double.Parse(input);

                if (fee < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }
                Console.WriteLine($"Increase: {fee:f2}");
                sum += fee;

                input = Console.ReadLine();
            }

            Console.WriteLine($"Total: {sum:f2}");
        }
    }
}
