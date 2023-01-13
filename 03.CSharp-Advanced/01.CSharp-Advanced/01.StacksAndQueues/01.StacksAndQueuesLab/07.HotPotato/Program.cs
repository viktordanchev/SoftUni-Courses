using System;
using System.Collections.Generic;

namespace _07.HotPotato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            Queue<string> childs = new Queue<string>(names);

            int tosses = 1;
            while (childs.Count != 1)
            {
                string child = childs.Dequeue();

                if (tosses != n)
                {
                    childs.Enqueue(child);
                    tosses++;
                }
                else
                {
                    Console.WriteLine($"Removed {child}");
                    tosses = 1;
                }
            }

            Console.WriteLine($"Last is {childs.Dequeue()}");
        }
    }
}