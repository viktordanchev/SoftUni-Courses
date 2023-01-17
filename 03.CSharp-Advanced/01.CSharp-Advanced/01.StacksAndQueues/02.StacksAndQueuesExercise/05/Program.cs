using System;
using System.Collections.Generic;
using System.Linq;

namespace _05_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInTheBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(clothesInTheBox);

            int racks = 1;
            int sum = 0;
            while (stack.Count > 0)
            {
                int clothes = stack.Pop();
                if (clothes + sum <= rackCapacity)
                {
                    sum += clothes;
                    continue;
                }

                sum = 0;
                sum += clothes;
                racks++;
            }

            Console.WriteLine(racks);
        }
    }
}
