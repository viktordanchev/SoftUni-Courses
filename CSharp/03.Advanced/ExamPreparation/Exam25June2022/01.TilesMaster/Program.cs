using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.TilesMaster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> locationByTileAreaNeeded = new Dictionary<string, int>()
            {
                ["Sink"] = 40,
                ["Oven"] = 50,
                ["Countertop"] = 60,
                ["Wall"] = 70
            };
            Dictionary<string, int> locationByCount = new Dictionary<string, int>();

            Stack<int> whiteTilesArea = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> greyTilesArea = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (whiteTilesArea.Count > 0 && greyTilesArea.Count > 0)
            {
                int whiteTileArea = whiteTilesArea.Pop();
                int greyTileArea = greyTilesArea.Dequeue();

                bool doesItMatch = false;

                if (whiteTileArea == greyTileArea)
                {
                    foreach (var location in locationByTileAreaNeeded)
                    {
                        if (whiteTileArea + greyTileArea == location.Value)
                        {
                            doesItMatch = true;

                            if (!locationByCount.ContainsKey(location.Key))
                            {
                                locationByCount.Add(location.Key, 1);
                                break;
                            }

                            locationByCount[location.Key]++;
                            break;
                        }
                    }

                    if (!doesItMatch)
                    {
                        if (!locationByCount.ContainsKey("Floor"))
                        {
                            locationByCount.Add("Floor", 1);
                            continue;
                        }

                        locationByCount["Floor"]++;
                        continue;
                    }
                }
                else
                {
                    whiteTileArea /= 2;
                    whiteTilesArea.Push(whiteTileArea);
                    greyTilesArea.Enqueue(greyTileArea);
                }
            }

            if (whiteTilesArea.Count == 0)
            {
                Console.WriteLine("White tiles left: none");
            }
            else
            {
                Console.WriteLine($"White tiles left: {string.Join(", ", whiteTilesArea)}");
            }

            if (greyTilesArea.Count == 0)
            {
                Console.WriteLine("Grey tiles left: none");
            }
            else
            {
                Console.WriteLine($"Grey tiles left: {string.Join(", ", greyTilesArea)}");
            }

            locationByCount = locationByCount
                .OrderByDescending(c => c.Value)
                .ThenBy(l => l.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var location in locationByCount)
            {
                Console.WriteLine($"{location.Key}: {location.Value}");
            }
        }
    }
}