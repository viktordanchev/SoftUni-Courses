using System;

namespace _10.MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int oddSum = GetSumOfOddDigits(Math.Abs(number));
            int evenSum = GetSumOfEvenDigits(Math.Abs(number));

            int result = GetMultipleOfEvenAndOdds(oddSum, evenSum);
            Console.WriteLine(result);
        }

        static int GetSumOfEvenDigits(int number)
        {
            int evenNum = 0;
            int currDigit = 0;
            int currNum = number;

            while (currNum > 0)
            {
                currDigit = currNum % 10;

                if (currDigit % 2 == 0)
                {
                    evenNum += currDigit;
                }

                currNum /= 10;
            }

            return evenNum;
        }

        static int GetSumOfOddDigits(int number)
        {
            int oddSum = 0;
            int currDigit = 0;
            int currNum = number;

            while (currNum > 0)
            {
                currDigit = currNum % 10;

                if (currDigit % 2 == 1)
                {
                    oddSum += currDigit;
                }

                currNum /= 10;
            }

            return oddSum;
        }

        static int GetMultipleOfEvenAndOdds(int oddSum, int evenSum)
        {
            int result = oddSum * evenSum;

            return result;
        }
    }
}
