using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Gauss_Trick
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();

            if (numbers.Count % 2 == 0)
            {
                List<int> sum = GetSumOfFirstAndLastIndexEvenList(numbers);
                Console.WriteLine(string.Join(' ', sum));
            }
            else
            {
                List<int> sum = GetSumOfFirstAndLastIndexOddList(numbers);
                Console.WriteLine(string.Join(' ', sum));
            }
        }

        static List<int> GetSumOfFirstAndLastIndexOddList(List<int> numbers)
        {
            List<int> sumOfNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;

                if (i == numbers.Count - 1)
                {
                    sumOfNumbers.Add(numbers[i]);
                    return sumOfNumbers;
                }

                sum = numbers[i] + numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                sumOfNumbers.Add(sum);
            }

            return sumOfNumbers;
        }

        static List<int> GetSumOfFirstAndLastIndexEvenList(List<int> numbers)
        {
            List<int> sumOfNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int sum = 0;

                sum = numbers[i] + numbers[numbers.Count - 1];
                numbers.RemoveAt(numbers.Count - 1);
                sumOfNumbers.Add(sum);
            }

            return sumOfNumbers;
        }
    }
}
