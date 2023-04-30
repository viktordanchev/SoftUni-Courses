using System;

namespace _05.AddAndSubtract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int sum = GetSumOfFirstAndSecondNums(firstNum, secondNum);
            int result = SubtractThirdNumFromSum(sum, thirdNum);
            Console.WriteLine(result);
        }

        static int GetSumOfFirstAndSecondNums(int firstNum, int secondNum)
        {
            int sum = firstNum + secondNum;
            return sum;
        }

        static int SubtractThirdNumFromSum(int sum, int thirdNum)
        {
            int result = sum - thirdNum;
            return result;
        }
    }
}
