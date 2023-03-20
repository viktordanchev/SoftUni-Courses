using System;
using System.Collections.Generic;

namespace SumOfIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> map = new Dictionary<int, string>()
            {
                [1] = "a",
                [2] = "b",
                [3] = "c"
            };

            map.Remove(2);
            map.Add(4, "da");

            Console.WriteLine();
        }
    }
}
