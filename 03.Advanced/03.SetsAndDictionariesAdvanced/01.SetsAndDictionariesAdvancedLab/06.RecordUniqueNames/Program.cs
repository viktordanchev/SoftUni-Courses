using System;
using System.Collections.Generic;

namespace _06.RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> names = new HashSet<string>();

            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                names.Add(Console.ReadLine());
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}
