using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Predicate<int> even = n => n % 2 == 0;
            Predicate<int> odd = n => n % 2 != 0;

            int[] bounds = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            List<int> numbers = new List<int>();
            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                numbers.Add(i);
            }

            string command = Console.ReadLine();
            if (command == "even")
            {
                numbers = numbers.FindAll(even);
            }
            else
            {
                numbers = numbers.FindAll(odd);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}