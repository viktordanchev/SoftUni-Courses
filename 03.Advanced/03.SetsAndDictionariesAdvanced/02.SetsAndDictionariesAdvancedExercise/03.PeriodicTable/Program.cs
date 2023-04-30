using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueElements = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] element = Console.ReadLine().Split();

                for (int j = 0; j < element.Length; j++)
                {
                    uniqueElements.Add(element[j]);
                }
            }

            Console.WriteLine(string.Join(' ', uniqueElements));
        }
    }
}