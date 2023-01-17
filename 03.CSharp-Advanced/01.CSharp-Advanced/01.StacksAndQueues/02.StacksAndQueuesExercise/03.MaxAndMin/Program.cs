using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MaxAndMin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < counter; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = input[0];

                switch (command)
                {
                    case 1:
                        int number = input[1];
                        stack.Push(number);
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                            break;
                        }

                        continue;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                            break;
                        }

                        continue;
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
