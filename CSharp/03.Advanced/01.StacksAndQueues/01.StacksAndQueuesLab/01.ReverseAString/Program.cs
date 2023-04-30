using System;
using System.Collections.Generic;

namespace _01.ReverseAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> reversedInput = new Stack<char>();

            foreach (char chr in input)
            {
                reversedInput.Push(chr);
            }

            while (reversedInput.Count != 0)
            {
                Console.Write(reversedInput.Pop());
            }
        }
    }
}
