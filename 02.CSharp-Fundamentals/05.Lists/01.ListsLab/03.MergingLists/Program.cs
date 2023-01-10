using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace _03.MergingLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondNums = Console.ReadLine().Split().Select(int.Parse).ToList();

            int largerList = GetLargerList(firstNums, secondNums);
            List<int> combinedList = CreateList(firstNums, secondNums, largerList);
            Console.WriteLine(string.Join(' ', combinedList));
        }

        static int GetLargerList(List<int> firstNums, List<int> secondNums)
        {
            int largerList = 0;

            if (firstNums.Count > secondNums.Count)
            {
                return largerList = firstNums.Count;
            }
            else
            {
                return largerList = secondNums.Count;
            }
        }

        static List<int> CreateList(List<int> firstNums, List<int> secondNums, int largerList)
        {
            List<int> combinedList = new List<int>();

            for (int i = 0; i < largerList; i++)
            {
                if (i >= firstNums.Count)
                {
                    combinedList.Add(secondNums[i]);
                    continue;
                }
                else if (i >= secondNums.Count)
                {
                    combinedList.Add(firstNums[i]);
                    continue;
                }

                combinedList.Add(firstNums[i]);
                combinedList.Add(secondNums[i]);
            }

            return combinedList;
        }
    }
}
