using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            int squaring = width * length * height;

            int totalSum = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Done")
                {
                    break;
                }

                int sum = int.Parse(input);

                totalSum += sum;

                if (totalSum > squaring)
                {
                    break;
                }

            }

            if (squaring > totalSum)
            {
                Console.WriteLine($"{squaring - totalSum} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {totalSum - squaring} Cubic meters more.");
            }
        }
    }
}
