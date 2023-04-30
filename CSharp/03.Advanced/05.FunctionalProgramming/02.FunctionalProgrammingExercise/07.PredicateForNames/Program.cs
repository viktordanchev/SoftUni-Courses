using System;

namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> filterName = n => n.Length <= nameLength;

            foreach (var name in names)
            {
                if (filterName(name))
                {
                    Console.WriteLine(name);
                }
            }
        }
    }
}