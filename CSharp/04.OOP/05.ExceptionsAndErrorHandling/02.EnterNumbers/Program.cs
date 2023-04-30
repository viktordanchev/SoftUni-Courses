using System;
using System.Collections.Generic;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new();

            while (numbers.Count < 10)
            {
                try
                {
                    int number = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Invalid Number!");
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void ReadNumber(int start, int end)
        {
            
        }
    }
}
