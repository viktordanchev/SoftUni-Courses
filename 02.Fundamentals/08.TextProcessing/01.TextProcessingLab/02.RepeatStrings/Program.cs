using System;

namespace _02.RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    Console.Write(word);
                }
            }
        }
    }
}
