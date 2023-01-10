using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountCharsInAString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ');
            Dictionary<char, int> counts = new Dictionary<char, int>();
            List<char> chars = new List<char>();

            FillCharArray(words, chars);

            foreach (var currChar in chars)
            {
                if (!counts.ContainsKey(currChar))
                {
                    counts.Add(currChar, 0);
                }

                counts[currChar]++;
            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }

        static List<char> FillCharArray(string[] words, List<char> chars)
        {
            string currWord;
            int index = 0;

            for (int i = 0; i < words.Length; i++)
            {
                currWord = words[i];

                foreach (var currChar in currWord)
                {
                    chars.Add(currChar);
                }

            }

            return chars;
        }
    }
}