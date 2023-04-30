using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> itemByResourcesNeeded = new Dictionary<string, int>()
            {
                ["Patch"] = 30,
                ["Bandage"] = 40,
                ["MedKit"] = 100
            };
            Dictionary<string, int> itemByCount = new Dictionary<string, int>();

            Queue<int> textiles = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> medicaments = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int remainingResources = 0;
            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int textile = textiles.Dequeue();
                int medicament = medicaments.Peek();

                int sum = textile + medicament;

                if (itemByResourcesNeeded.Any(i => i.Value == sum))
                {
                    var item = itemByResourcesNeeded.Where(x => x.Value == sum).First();

                    if (!itemByCount.ContainsKey(item.Key))
                    {
                        itemByCount.Add(item.Key, 1);
                    }
                    else
                    {
                        itemByCount[item.Key]++;
                    }

                    medicaments.Pop();
                }
                else
                {
                    if (sum > 100)
                    {
                        if (!itemByCount.ContainsKey("MedKit"))
                        {
                            itemByCount.Add("MedKit", 1);
                        }
                        else
                        {
                            itemByCount["MedKit"]++;
                        }

                        remainingResources = sum - 100;

                        medicaments.Pop();
                        medicaments.Push(medicaments.Pop() + remainingResources);
                    }
                    else
                    {
                        medicaments.Push(medicaments.Pop() + 10);
                    }
                }
            }

            itemByCount = itemByCount.OrderByDescending(c => c.Value).ThenBy(i => i.Key).ToDictionary(x => x.Key, x => x.Value);

            if (textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (textiles.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            foreach (var item in itemByCount)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}