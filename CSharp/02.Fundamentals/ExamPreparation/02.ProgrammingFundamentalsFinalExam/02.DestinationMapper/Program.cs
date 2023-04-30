using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(\=|\/)(?<name>([A-Z]{1}[A-z]{2,})(\s[A-Z]{1}[A-z]{2,})?)\1";

            string text = Console.ReadLine();

            MatchCollection mathes = Regex.Matches(text, pattern);
            string[] locations = mathes.Select(m => m.Groups["name"].Value).ToArray();

            int travelPoints = locations.Sum(m => m.Length);

            Console.WriteLine($"Destinations: {string.Join(", ", locations)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}
