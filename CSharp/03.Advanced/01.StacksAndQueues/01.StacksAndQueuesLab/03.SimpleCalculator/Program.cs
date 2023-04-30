using System;
using System.Collections.Generic;

namespace _03.SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Stack<string> stack = new Stack<string>(input);

            int result = 0;
            while (stack.Count > 1)
            {
                int number = int.Parse(stack.Pop());
                string operation = stack.Pop();

                if (operation == "+")
                {
                    result += number;
                }
                else
                {
                    result -= number;
                }
            }
            result += int.Parse(stack.Pop());

            Console.WriteLine(result);
        }
    }
}
