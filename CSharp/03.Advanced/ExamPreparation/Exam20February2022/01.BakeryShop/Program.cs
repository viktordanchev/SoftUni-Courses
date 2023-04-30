using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> productsByCount = new Dictionary<string, int>();
            Dictionary<string, int> productsByWaterPercentages = new Dictionary<string, int>()
            {
                ["Croissant"] = 50,
                ["Muffin"] = 40,
                ["Baguette"] = 30,
                ["Bagel"] = 20
            };


            Queue<double> waterQueue = new Queue<double>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            Stack<double> flourQueue = new Stack<double>(Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));

            while (waterQueue.Count > 0 && flourQueue.Count > 0)
            {
                bool canBeMade = false;
                double water = waterQueue.Dequeue();
                double flour = flourQueue.Pop();

                double sum = water + flour;
                int waterPercentages = (int)(water * 100) / (int)sum;
                int flourPercentages = 100 - waterPercentages;

                if (waterPercentages == 50)
                {
                    AddToDictionary(productsByWaterPercentages, productsByCount, waterPercentages);
                }
                else if (waterPercentages == 40)
                {
                    AddToDictionary(productsByWaterPercentages, productsByCount, waterPercentages);
                }
                else if (waterPercentages == 30)
                {
                    AddToDictionary(productsByWaterPercentages, productsByCount, waterPercentages);
                }
                else if (waterPercentages == 20)
                {
                    AddToDictionary(productsByWaterPercentages, productsByCount, waterPercentages);
                }
                else
                {
                    double cut = flour - water;
                    flourQueue.Push(cut);

                    if (!productsByCount.ContainsKey("Croissant"))
                    {
                        productsByCount.Add("Croissant", 1);
                    }
                    else
                    {
                        productsByCount["Croissant"]++;
                    }
                }
            }

            productsByCount = productsByCount.OrderByDescending(c => c.Value).ThenBy(p => p.Key).ToDictionary(k => k.Key, v => v.Value);

            foreach (var product in productsByCount)
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }

            if (waterQueue.Count == 0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: { string.Join(", ", waterQueue)}");
            }

            if(flourQueue.Count == 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flourQueue)}");
            }
        }

        static void AddToDictionary(Dictionary<string, int> productsByWaterPercentages, Dictionary<string, int> productsByCount, int waterPercentages)
        {
            foreach (var product in productsByWaterPercentages)
            {
                if (waterPercentages == product.Value)
                {
                    if (!productsByCount.ContainsKey(product.Key))
                    {
                        productsByCount.Add(product.Key, 1);
                    }
                    else
                    {
                        productsByCount[product.Key]++;
                    }

                    return;
                }
            }
        }
    }
}