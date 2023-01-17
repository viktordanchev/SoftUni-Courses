using System;
using System.Collections.Generic;

namespace _09_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string text = string.Empty;

            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ");
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        stack.Push(text);
                        text += input[1];
                        break;
                    case 2:
                        stack.Push(text);
                        int count = int.Parse(input[1]);
                        text = text.Remove(text.Length - count);
                        break;
                    case 3:
                        int index = int.Parse(input[1]) - 1;
                        Console.WriteLine(text[index]);
                        break;
                    case 4:
                        text = stack.Pop();
                        break;
                }
            }
        }
    }
}
