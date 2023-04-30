using System;

namespace _04.SumOfChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChars = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = 1; i <= numberOfChars; i++)
            {
                char currChar = char.Parse(Console.ReadLine());

                sum += (int)currChar;
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}
