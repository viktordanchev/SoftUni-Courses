using System;
using System.Linq;

namespace _03.CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> getSmallestNum = n => n.Min();

            Console.WriteLine(getSmallestNum(numbers));
        }
    }
}