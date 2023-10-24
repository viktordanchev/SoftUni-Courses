using _03.MinHeap;
using System;

namespace MinHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new PriorityQueue<int>();
            c.Add(4);
            c.Add(2);
            c.Add(1);
            c.Add(3);
            Console.WriteLine(c.ExtractMin());
            Console.WriteLine(c.ExtractMin());
            Console.WriteLine(c.ExtractMin());
            Console.WriteLine(c.ExtractMin());
        }
    }
}
