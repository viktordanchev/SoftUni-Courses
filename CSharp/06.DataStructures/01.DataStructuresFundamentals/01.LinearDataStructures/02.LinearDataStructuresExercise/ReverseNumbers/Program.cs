using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack<string>();

            var input = Console.ReadLine().Split(" ").ToArray();

            foreach (var item in input)
            {
                stack.Push(item);
            }

            Console.WriteLine(string.Join(" ", stack));
        }
    }
}
