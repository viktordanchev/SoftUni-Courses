using System;

namespace _04.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();

            foreach (string bannedWord in bannedWords)
            {
                string asteriks = "";
                for (int i = 0; i < bannedWord.Length; i++)
                {
                    asteriks += "*";
                }

                text = text.Replace(bannedWord, asteriks);
            }
            

            Console.WriteLine(text);
        }
    }
}