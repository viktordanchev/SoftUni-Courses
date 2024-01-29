using System;
using System.Collections.Generic;

namespace _01.HelloSoftUni
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("([]])"));
        }

        public static bool IsValid(string s)
        {
            var parentheses = s.ToCharArray();
            var stack = new Stack<char>();

            for (int i = 0; i < parentheses.Length; i++)
            {
                var curr = parentheses[i];

                stack.Push(curr);

                if (curr == ')' || curr == '}' || curr == ']')
                {
                    stack.Pop();

                    if(stack.Count == 0)
                    {
                        break;
                    }

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}
