using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfClothes = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> colorClothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numberOfClothes; i++)
            {
                string[] color = Console.ReadLine().Split(" -> ");
                string[] clothes = color[1].Split(',');

                if (!colorClothes.ContainsKey(color[0]))
                {
                    colorClothes.Add(color[0], new Dictionary<string, int>());
                }

                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!colorClothes[color[0]].ContainsKey(clothes[j]))
                    {
                        colorClothes[color[0]].Add(clothes[j], 0);
                    }

                    colorClothes[color[0]][clothes[j]]++;
                }
            }

            string[] toSearch = Console.ReadLine().Split();
            string garmentColor = toSearch[0];
            string garmentToSearch = toSearch[1];

            foreach (var color in colorClothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var garment in color.Value)
                {
                    if (color.Key == garmentColor && garment.Key == garmentToSearch)
                    {
                        Console.WriteLine($"* {garment.Key} - {garment.Value} (found!)");
                        continue;
                    }

                    Console.WriteLine($"* {garment.Key} - {garment.Value}");    
                }
            }
        }
    }
}