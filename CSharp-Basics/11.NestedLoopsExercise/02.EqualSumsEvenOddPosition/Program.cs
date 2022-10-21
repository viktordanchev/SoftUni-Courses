using System;

namespace _02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            int evenSum;
            int oddSum;

            for (int i = firstNum; i <= secondNum; i++)
            {
                evenSum = 0;
                oddSum = 0;

                string currentNum = i.ToString();

                for (int j = 0; j < currentNum.Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        evenSum += currentNum[j];
                    }
                    else
                    {
                        oddSum += currentNum[j];
                    }

                }
                if (evenSum == oddSum)
                {
                    Console.Write(currentNum + " ");
                }
            }
        }
    }
}
