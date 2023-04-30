using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.OddOccurrences
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(" ").Select(w => w.ToLower()).ToArray();
            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                if (counts.ContainsKey(word))
                {
                    counts[word]++;
                }
                else
                {
                    counts.Add(word, 1);
                }
            }

            foreach (var count in counts)
            {
                if (count.Value % 2 == 1)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
