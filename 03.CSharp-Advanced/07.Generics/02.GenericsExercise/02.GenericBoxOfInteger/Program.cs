using System;

namespace _02.GenericBoxOfInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>();

                box.BoxValue = int.Parse(Console.ReadLine());

                Console.WriteLine(box.ToString());
            }
        }
    }
}