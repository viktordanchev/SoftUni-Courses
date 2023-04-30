using System;
using System.Linq;

namespace _06.EqualSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            if (numbers.Length == 1)
            {
                Console.WriteLine(0);
            }

            int rightLength = numbers.Length - 1;
            for (int i = 1; i < numbers.Length; i++)
            {
                int leftSum = 0;
                int rightSum = 0;
                int leftCurrIndex = 1;
                int rightCurrIndex = 1;

                for (int left = 0; left < i; left++)
                {
                    leftSum += numbers[i - leftCurrIndex];
                    leftCurrIndex++;
                }

                for (int right = 1; right < rightLength; right++)
                {
                    rightSum += numbers[i + rightCurrIndex];
                    rightCurrIndex++;
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    break;
                }

                if (i + 1 == numbers.Length)
                {
                    Console.WriteLine("no");
                    break;
                }

                rightLength--;
            }
        }
    }
}
