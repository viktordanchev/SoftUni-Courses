using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Intrinsics.Arm;

namespace _03.PlantDiscovery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Plant> plants = new List<Plant>();
            int numberOfPlants = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPlants; i++)
            {
                string[] plantInfo = Console.ReadLine()
                    .Split("<->", StringSplitOptions.RemoveEmptyEntries);
                string name = plantInfo[0];
                string rarity = plantInfo[1];

                Plant plant = plants.FirstOrDefault(p => p.Name == name);

                if (plant != null)
                {
                    plant.Rarity = rarity;
                    continue;
                }

                plant = new Plant(name, rarity);

                plants.Add(plant);
            }

            string input = Console.ReadLine();

            while (input != "Exhibition")
            {
                string[] data = input
                    .Split(new char[] { ' ', ':', '-' }, StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                string name = data[1];

                Plant plant = plants.FirstOrDefault(p => p.Name == name);

                if (plant == null)
                {
                    Console.WriteLine("error");
                    input = Console.ReadLine();
                    continue;
                }

                switch (command)
                {
                    case "Rate":
                        double rating = double.Parse(data[2]);
                        plant.AddRating(rating);
                        break;
                    case "Update":
                        string rarity = data[2];
                        plant.Rarity = rarity;
                        break;
                    case "Reset":
                        plant.Rating.Clear();
                        plant.Rating.Add(0);
                        break;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Plants for the exhibition:");

            foreach (var plant in plants)
            {
                Console.WriteLine(plant);
            }
        }

        class Plant
        {
            public Plant(string name, string rarity)
            {
                Name = name;
                Rarity = rarity;
                Rating = new List<double>();
            }

            public string Name { get; set; }
            public string Rarity { get; set; }
            public List<double> Rating { get; private set; }

            public void AddRating(double rating)
            {
                Rating.Add(rating);
            }

            public override string ToString()
            {
                if (Rating.Count == 0)
                    Rating.Add(0);

                return $"- {Name}; Rarity: {Rarity}; Rating: {Rating.Sum() / Rating.Count:f2}";
            }
        }
    }
}
