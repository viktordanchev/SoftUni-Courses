using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            SortedDictionary<int, int> count = new SortedDictionary<int, int>();

            foreach (var number in numbers)
            {
                if (!count.ContainsKey(number))
                {
                    count.Add(number, 1);
                }
                else
                {
                    count[number]++;
                }
            }

            foreach (var item in count)
            {
                Console.WriteLine(item.Key + " " + "->" + " " + item.Value);
            }
        }
    }
}
