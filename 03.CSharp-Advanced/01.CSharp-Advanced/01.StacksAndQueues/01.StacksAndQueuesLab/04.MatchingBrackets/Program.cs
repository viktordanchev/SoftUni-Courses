using System;
using System.Collections.Generic;

namespace _04.MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> openerBracketIndexes = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openerBracketIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int start = openerBracketIndexes.Pop();

                    for (int j = start; j <= i; j++)
                    {
                        Console.Write(expression[j]);
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
