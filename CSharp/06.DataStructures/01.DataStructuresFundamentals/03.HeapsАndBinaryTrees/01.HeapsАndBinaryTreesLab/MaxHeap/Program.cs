using _03.MaxHeap;
using System;

namespace MaxHeap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var c = new MaxHeap<int>();

            c.Add(1);
            c.Add(2);   
            c.Add(3);
            c.Add(4);
            c.Add(5);

            Console.WriteLine(c.ExtractMax());
            Console.WriteLine(c.ExtractMax());
        }
    }
}
