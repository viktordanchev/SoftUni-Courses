using System;

namespace _01.IntegerOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int firstOperation = firstNum + secondNum;

            int thirdNum = int.Parse(Console.ReadLine());
            int secondOperation = firstOperation / thirdNum;

            int fourthNum = int.Parse(Console.ReadLine());
            int thirdOperation = secondOperation * fourthNum;

            Console.WriteLine(thirdOperation);
        }
    }
}
