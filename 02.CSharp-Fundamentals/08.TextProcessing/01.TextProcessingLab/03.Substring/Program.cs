using System;

namespace _03.Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string wordToRemove = Console.ReadLine();
            string words = Console.ReadLine();
            string finalWords = string.Empty;

            while (words.Contains(wordToRemove))
            {
                int startIndex = words.IndexOf(wordToRemove);

                words = words.Remove(startIndex, wordToRemove.Length);
            }

            Console.WriteLine(words);
        }
    }
}