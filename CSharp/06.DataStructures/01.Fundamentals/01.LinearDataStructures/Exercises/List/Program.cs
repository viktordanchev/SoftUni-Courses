using System;
using System.Collections.Generic;

namespace Problem03.ReversedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new ReversedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Insert(1, 6);
            Console.WriteLine(string.Join(" ", list));
        }
    }
}
