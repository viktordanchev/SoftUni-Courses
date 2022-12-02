using System;

namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int currNum = 1; currNum <= number; currNum++)
            {
                bool numberIsDivisibleBy8 = CheckIfNumIsDivisibleBy8(currNum);
                bool numberHoldOddDigit = CheckIfNumHoldOddDigit(currNum);

                if (numberIsDivisibleBy8 && numberHoldOddDigit)
                {
                    Console.WriteLine(currNum);
                }
            }
        }

        static bool CheckIfNumHoldOddDigit(int i)
        {
            int remainder, counter = 0;

            while (i > 0)
            {
                remainder = i % 10;
                i /= 10;

                if (remainder % 2 == 1)
                {
                    counter++;
                }
            }

            if (counter >= 1)
            {
                return true;
            }

            return false;
        }

        static bool CheckIfNumIsDivisibleBy8(int i)
        {
            int remainder, sum = 0;

            while (i > 0)
            {
                remainder = i % 10;
                i /= 10;
                sum += remainder;
            }

            if (sum % 8 == 0)
            {
                return true;
            }

            return false;
        }
    }
}
