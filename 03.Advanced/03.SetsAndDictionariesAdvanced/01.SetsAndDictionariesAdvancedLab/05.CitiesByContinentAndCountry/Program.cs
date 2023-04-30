using System;
using System.Collections.Generic;

namespace _05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < number; i++)
            {
                string[] data = Console.ReadLine().Split();
                string continent = data[0];
                string countrie = data[1];
                string city = data[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(countrie))
                {
                    continents[continent].Add(countrie, new List<string>());
                }

                continents[continent][countrie].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var countrie in continent.Value)
                {
                    Console.WriteLine($"{countrie.Key} -> {string.Join(", ", countrie.Value)}");
                }
            }
        }
    }
}
