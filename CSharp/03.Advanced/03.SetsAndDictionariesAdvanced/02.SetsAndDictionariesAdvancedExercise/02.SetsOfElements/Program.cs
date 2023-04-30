using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int firstLength = input[0];
            int secondLength = input[1];

            int[] firstNumbers = new int[firstLength];
            int[] secondNumbers = new int[secondLength];

            for (int i = 0; i < firstLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                firstNumbers[i] = number;
            }

            for (int i = 0; i < secondLength; i++)
            {
                int number = int.Parse(Console.ReadLine());

                secondNumbers[i] = number;
            }

            HashSet<int> uniqueElements = new HashSet<int>();

            foreach (int firstNumber in firstNumbers)
            {
                foreach (var secondNumber in secondNumbers)
                {
                    if (firstNumber == secondNumber)
                    {
                        uniqueElements.Add(firstNumber);
                    }
                }
            }

            Console.WriteLine(string.Join(' ', uniqueElements));
        }
    }
}