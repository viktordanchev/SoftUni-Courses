using System;

namespace _12.EvenNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            while (true)
            {
                number = Math.Abs(number);

                if (number % 2 == 1)
                {
                    Console.WriteLine($"Please write an even number.");
                }
                else
                {
                    Console.WriteLine($"The number is: {number}");
                    break;
                }

                number = int.Parse(Console.ReadLine());
            }
        }
    }
}
