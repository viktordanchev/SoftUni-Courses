using System;

namespace _02.KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> printName = n => Console.WriteLine($"Sir {n}");

            foreach (string name in names) 
            {
                printName(name);
            }
        }
    }
}