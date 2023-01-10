using System;

namespace _11.MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            char @operator = char.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            double result = Calculate(firstNum, @operator, secondNum);
            Console.WriteLine(result);
        }

        static double Calculate(int firstNum, char @operator, int secondNum)
        {
            double result = 0;

            if (@operator == '/')
            {
                result = firstNum / secondNum;
            }
            else if (@operator == '*')
            {
                result = firstNum * secondNum;
            }
            else if (@operator == '+')
            {
                result = firstNum + secondNum;
            }
            else if (@operator == '-')
            {
                result = firstNum - secondNum;
            }

            return result;
        }
    }
}
