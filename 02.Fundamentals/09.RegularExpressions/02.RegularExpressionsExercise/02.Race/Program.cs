using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace _02.Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(", ").ToList();
            string info = Console.ReadLine();
            int sum = 0;

            Dictionary<string, int> nameByDistance = new Dictionary<string, int>();

            while (info != "end of the race")
            {
                MatchCollection matchedNames = Regex.Matches(info, @"(?<name>[A-Za-z])");
                MatchCollection matchedDigits = Regex.Matches(info, @"(?<digits>\d)");

                string name = string.Join("", matchedNames);
                string digits = string.Join("", matchedDigits);

                if (!nameByDistance.ContainsKey(name))
                {
                    for (int i = 0; i < digits.Length; i++)
                    {
                        sum += int.Parse(digits[i].ToString());
                    }

                    nameByDistance.Add(name, sum);
                }
                else
                {
                    for (int i = 0; i < digits.Length; i++)
                    {
                        sum += int.Parse(digits[i].ToString());
                    }

                    nameByDistance[name] += sum;
                }

                sum = 0;
                info = Console.ReadLine();
            }
        }
    }
}
