using System;

namespace _01.SmallestOfThreeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            int smallestNum = GetTheSmallestNumber(firstNum, secondNum, thirdNum);
            Console.WriteLine(smallestNum);
        }

        static int GetTheSmallestNumber(int firstNum, int secondNum, int thirdNum)
        {
            return Math.Min(Math.Min(firstNum, secondNum), thirdNum);  
        }
    }
}
