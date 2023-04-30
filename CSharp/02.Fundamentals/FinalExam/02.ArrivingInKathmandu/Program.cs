using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.ArrivingInKathmandu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"^(?<name>(\w+|\!|\@|\#|\$|\?)*)\=(?<length>[0-9]+)\<\<(?<code>.+)$";

            string message = Console.ReadLine();
            while (message != "Last note")
            {
                Match match = Regex.Match(message, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int length = int.Parse(match.Groups["length"].Value);
                    string code = match.Groups["code"].Value;

                    if (code.Length == length)
                    {
                        string correctName = string.Empty;

                        foreach (var currChar in name)
                        {
                            if (char.IsLetterOrDigit(currChar))
                                correctName += currChar;
                        }

                        Console.WriteLine($"Coordinates found! {correctName} -> {code}");

                        message = Console.ReadLine();
                        continue;
                    }
                }

                Console.WriteLine("Nothing found!");

                message = Console.ReadLine();
            }
        }
    }
}
