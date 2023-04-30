using System;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();

            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";

            MatchCollection matches = Regex.Matches(names, pattern);

            Console.WriteLine(string.Join(' ', matches));
        }
    }
}