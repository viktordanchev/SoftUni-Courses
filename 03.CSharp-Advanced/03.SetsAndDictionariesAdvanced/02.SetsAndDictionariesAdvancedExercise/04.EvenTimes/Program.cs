using System;
using System.Collections.Generic;

namespace _04.EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<int, int> numberCount = new Dictionary<int, int>();

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!numberCount.ContainsKey(number))
                {
                    numberCount.Add(number, 0);
                }

                numberCount[number]++;
            }

            foreach (var number in numberCount)
            {
                if (number.Value % 2 == 0)
                {
                    Console.WriteLine(number.Key);
                }
            }
        }
    }
}