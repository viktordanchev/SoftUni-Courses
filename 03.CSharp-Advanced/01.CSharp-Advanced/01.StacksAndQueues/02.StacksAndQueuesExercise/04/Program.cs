using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);
            List<int> ordersLeft = new List<int>();

            Console.WriteLine(queue.Max());

            int ordersSum = 0;
            while (queue.Count > 0)
            {
                int order = queue.Dequeue();

                if (order + ordersSum > foodQuantity)
                {
                    ordersLeft.Add(order);
                }

                ordersSum += order;
            }

            if (ordersSum <= foodQuantity)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", ordersLeft)}");
            }
        }
    }
}
