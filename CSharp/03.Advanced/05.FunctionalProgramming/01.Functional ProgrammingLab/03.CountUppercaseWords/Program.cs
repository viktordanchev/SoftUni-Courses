using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> checkForUpper = w => char.IsUpper(w[0]);

            var upperWords = words.Where(w => checkForUpper(w));

            foreach (var word in upperWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}