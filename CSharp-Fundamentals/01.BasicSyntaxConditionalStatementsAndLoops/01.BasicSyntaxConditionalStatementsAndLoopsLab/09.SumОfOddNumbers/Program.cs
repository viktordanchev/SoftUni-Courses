using System;

namespace _09.SumОfOddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= number * 2; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                    sum += i;
                }
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
