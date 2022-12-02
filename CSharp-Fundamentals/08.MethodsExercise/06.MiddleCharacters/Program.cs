using System;

namespace _06.MiddleCharacters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            PrintMiddleChar(word);
        }

        static void PrintMiddleChar(string word)
        {
            if (word.Length % 2 == 1)
            {
                char middleChar = word[word.Length / 2];
                Console.WriteLine(middleChar);
            }

            if (word.Length % 2 == 0)
            {
                char middleChar = word[word.Length / 2 - 1];
                char secondMiddleChar = word[word.Length / 2];
                Console.WriteLine($"{middleChar}{secondMiddleChar}");
            }
        }
    }
}
