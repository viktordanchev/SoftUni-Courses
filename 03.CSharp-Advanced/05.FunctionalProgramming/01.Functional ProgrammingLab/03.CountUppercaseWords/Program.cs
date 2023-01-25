using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            
            //Func<string, bool> checkForUpper = w => char.IsUpper(w[0]);
            
            var uppersWords = words.Select(w => GetWordsStartWithUpperChar(words));
            
            foreach (var word in uppersWords)
            {
                Console.WriteLine(word);
            }
        }

        static string GetWordsStartWithUpperChar(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                string currWord = words[i];

                if (char.IsUpper(currWord[0]))
                {
                    return currWord;
                }
            }

            return string.Empty;
        }
    }
}
