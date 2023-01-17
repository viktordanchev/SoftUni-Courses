using System;
using System.Collections.Generic;

namespace _08_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string brackets = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < brackets.Length; i++)
            {
                if (brackets[i] == '{' || brackets[i] == '(' || brackets[i] == '[')
                {
                    stack.Push(brackets[i]);
                }
                else if (brackets[i] == '}' && (stack.Count == 0 || stack.Pop() != '{'))
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (brackets[i] == ')' && (stack.Count == 0 || stack.Pop() != '('))
                {
                    Console.WriteLine("NO");
                    return;
                }
                else if (brackets[i] == ']' && (stack.Count == 0 || stack.Pop() != '['))
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            Console.WriteLine("YES");
        }
    }
}
