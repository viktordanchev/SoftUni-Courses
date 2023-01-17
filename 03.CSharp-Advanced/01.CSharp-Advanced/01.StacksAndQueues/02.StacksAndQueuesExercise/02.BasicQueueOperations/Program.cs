using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.BasicQueue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] commands = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();

            int numOfElementsToEnqueue = commands[0];
            int numOfElementsToDequeue = commands[1];
            int numOfElementsToPeek = commands[2];

            for (int i = 0; i < numOfElementsToEnqueue; i++)
            {
                queue.Enqueue(numbers[i]);
            }

            for (int i = 0; i < numOfElementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            foreach (int num in queue)
            {
                if (num == numOfElementsToPeek)
                {
                    Console.WriteLine("true");
                    return;
                }
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
