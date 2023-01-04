using System;
using System.Linq;

namespace _05.DigitsLettersAndOther
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] digits = input.Where(chr => char.IsDigit(chr)).ToArray();
            char[] letters = input.Where(chr => char.IsLetter(chr)).ToArray();
            char[] others = input.Where(chr => !char.IsLetterOrDigit(chr)).ToArray();

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);
        }
    }
}