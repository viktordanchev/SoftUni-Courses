using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<name>[A-Za-z\s]+)<<(?<price>\d+(.\d+)?)!(?<quantity>\d+)\b";

            string input = Console.ReadLine();
            List<string> furnitures = new List<string>();
            double sum = 0;

            while (input != "Purchase")
            {
                Match match = Regex.Match(input, pattern);

                if (Regex.IsMatch(input, pattern))
                {
                    double value = double.Parse(match.Groups["price"].Value);
                    int quantity = int.Parse(match.Groups["quantity"].Value);
                    sum += value * quantity;

                    furnitures.Add(match.Groups["name"].Value);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine("Bought furniture:");
            furnitures.ForEach(Console.WriteLine);
            Console.WriteLine($"Total money spend: {sum:f2}");
        }
    }
}