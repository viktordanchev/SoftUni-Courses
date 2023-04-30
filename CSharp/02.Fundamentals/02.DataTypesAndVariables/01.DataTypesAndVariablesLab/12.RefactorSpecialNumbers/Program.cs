using System;

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;
            int currNum = 0;

            bool trueOrFalse = false;
            for (int i = 1; i <= number; i++)
            {
                currNum = i;

                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }

                trueOrFalse = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", currNum, trueOrFalse);

                sum = 0;
                i = currNum;
            }
        }
    }
}
