using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.AppendArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> numbers = Console.ReadLine().Split('|').Reverse().ToList();
            List<string> reversedNums = new List<string>();

            foreach (var number in numbers)
            {
                reversedNums.AddRange(number.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            }

            Console.WriteLine(string.Join(' ', reversedNums));
        }
    }
}
