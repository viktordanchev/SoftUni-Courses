using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                int currNum = queue.Dequeue();

                if (currNum % 2 == 0)
                {
                    queue.Enqueue(currNum);
                }
                else
                {
                    continue;
                }
            }

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
