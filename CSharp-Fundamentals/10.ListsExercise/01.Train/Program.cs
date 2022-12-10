using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());
            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    AddWagon(command, wagons);
                    command = Console.ReadLine().Split();
                    continue;
                }

                FillPassangersToSingleWagon(command, maxCapacityOfWagon, wagons);

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(' ', wagons));
        }

        static List<int> FillPassangersToSingleWagon(string[] command, int maxCapacityOfWagon, List<int> wagons)
        {
            int passangers = int.Parse(command[0]);

            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passangers <= maxCapacityOfWagon)
                {
                    wagons[i] += passangers;
                    break;
                }
            }

            return wagons;
        }

        static List<int> AddWagon(string[] command, List<int> wagons)
        {
            int passangers = int.Parse(command[1]);
            wagons.Add(passangers);
            return wagons;
        }
    }
}
