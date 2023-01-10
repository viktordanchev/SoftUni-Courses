using System;
using System.Collections.Generic;

namespace _03.MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<List<int>> ints = new List<List<int>>();

            ints.Add(new List<int>());
            ints.Add(new List<int> { 1, 2, 3 });

            Console.WriteLine(string.Join(' ', ints));

        }
    }
}
