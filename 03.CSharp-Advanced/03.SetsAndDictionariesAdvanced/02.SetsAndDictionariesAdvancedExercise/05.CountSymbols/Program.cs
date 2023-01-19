using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Dictionary<char, int> charCount = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                char currChar = text[i];

                if (!charCount.ContainsKey(currChar))
                {
                    charCount.Add(currChar, 0);
                }

                charCount[currChar]++;
            }

            charCount = charCount.OrderBy(c => c.Key).ToDictionary(c => c.Key, c => c.Value);

            foreach (var currChar in charCount)
            {
                Console.WriteLine($"{currChar.Key}: {currChar.Value} time/s");
            }
        }
    }
}