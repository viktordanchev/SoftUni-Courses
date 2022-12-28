using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resourceByQuantity = new Dictionary<string, int>();

            string resource = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            while (resource != "stop")
            {
                if (!resourceByQuantity.ContainsKey(resource))
                {
                    resourceByQuantity.Add(resource, quantity);
                }
                else
                {
                    resourceByQuantity[resource] += quantity;
                }

                resource = Console.ReadLine();
                if (resource != "stop")
                {
                    quantity = int.Parse(Console.ReadLine());
                }
            }

            foreach (var item in resourceByQuantity)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}