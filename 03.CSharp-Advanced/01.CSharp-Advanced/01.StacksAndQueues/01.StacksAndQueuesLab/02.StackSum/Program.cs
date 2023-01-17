using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            string[] input = Console.ReadLine().Split();

            while (true)
            {
                string command = input[0].ToLower();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        int firstNum = int.Parse(input[1]);
                        int secondNum = int.Parse(input[2]);

                        stack.Push(firstNum);
                        stack.Push(secondNum);
                        break;

                    case "remove":
                        int numbersToRemove = int.Parse(input[1]);

                        if (stack.Count < numbersToRemove)
                        {
                            break;
                        }

                        for (int i = 0; i < numbersToRemove; i++)
                        {
                            stack.Pop();
                        }
                        break;
                }

                input = Console.ReadLine().Split();
            }

            int sum = 0;
            while (stack.Count != 0)
            {
                sum += stack.Pop();
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}
