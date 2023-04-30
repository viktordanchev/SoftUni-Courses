using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativesAndReverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            bool isAllNumbersNegative = CheckIfAllNumsAreNegative(numbers);

            if (isAllNumbersNegative)
            {
                Console.WriteLine("empty");
            }
            else
            {
                List<int> positiveNumbers = RemoveNegativeNumbers(numbers);
                Console.WriteLine(string.Join(' ', positiveNumbers));
            }
        }

        static bool CheckIfAllNumsAreNegative(List<int> numbers)
        {
            int counter = 0;

            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    counter++;
                }
            }

            if (counter == numbers.Count)
            {
                return true;
            }

            return false;
        }

        static List<int> RemoveNegativeNumbers(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers.RemoveAt(i);
                    i--;
                }
            }

            numbers.Reverse();

            return numbers;
        }
    }
}
