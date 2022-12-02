using System;

namespace _02.VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int sum = PrintSumOfAllVowels(input);
            Console.WriteLine(sum);
        }

        static int PrintSumOfAllVowels(string input)
        {
            int sum = 0;

            string lowerInput = input.ToLower();
            foreach (char letter in lowerInput)
            {
                if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'o' || letter == 'u')
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
