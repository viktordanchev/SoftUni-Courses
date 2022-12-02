using System;

namespace _08.FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double firstResult = CalculateFirstFactorial(firstNum);
            double secondResult = CalculateFirstFactorial(secondNum);
            Console.WriteLine($"{firstResult / secondResult:f2}");
        }

        static double CalculateFirstFactorial(int firstNum)
        {
            double sum = 1;

            for (int i = firstNum; i > 0; i--)
            {
                sum *= i;
            }

            return sum;
        }

        static double CalculateSecondFactorial(int secondNum)
        {
            double sum = 1;

            for (int i = secondNum; i > 0; i--)
            { 
                sum *= i;
            }

            return sum;
        }
    }
}
