using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            int numOfElementsToPush = commands[0];
            int numOfElementsToPop = commands[1];
            int numOfElementsToPeek = commands[2];

            for (int i = 0; i < numOfElementsToPush; i++)
            {
                stack.Push(numbers[i]);
            }

            for (int i = 0; i < numOfElementsToPop; i++)
            {
                stack.Pop();
            }

            foreach (int num in stack)
            {
                if (num == numOfElementsToPeek)
                {
                    Console.WriteLine("true");
                    return;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
