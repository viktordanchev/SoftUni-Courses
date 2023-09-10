using System;
using System.Collections;

namespace CalcSequence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue();
            var number = int.Parse(Console.ReadLine());

            queue.Enqueue(number);
            for (int i = 1; i < 17; i++)
            {
                var currNumber = number;
                currNumber = currNumber + 1;
                queue.Enqueue(currNumber);
                currNumber = number;
                currNumber = currNumber * 2 + 1;
                queue.Enqueue(currNumber);
                currNumber = number;
                currNumber = currNumber + 2;
                queue.Enqueue(currNumber);
            }

            foreach (var item in queue)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
