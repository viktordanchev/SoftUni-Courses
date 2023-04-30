using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.GenericSwapMethodString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Box<string>> boxes = new List<Box<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<string> box = new Box<string>();

                box.BoxValue = Console.ReadLine();

                boxes.Add(box);
            }

            int[] swapCommands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            GenericMethod(boxes, swapCommands);

            foreach (var item in boxes)
            {
                Console.WriteLine(item.ToString());
            }
        }

        static void GenericMethod<T>(List<T> list, int[] swapCommands)
        {
            int firstIndex = swapCommands[0];
            int secondIndex = swapCommands[1];

            T currElement = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = currElement;
        }
    }
}