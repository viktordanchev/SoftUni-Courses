using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.AdAstra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Food> list = new List<Food>();
            int allCalories = 0;
            string pattern = @"(\#|\|)(?<name>([A-z]+)(\s[A-z]+)?)\1(?<date>[0-9]{2}\/[0-9]{2}\/[0-9]{2})\1(?<calories>[0-9]+)\1";


            string text = Console.ReadLine();

            MatchCollection matches = Regex.Matches(text, pattern);

            for (int i = 0; i < matches.Count; i++)
            {
                string name = matches[i].Groups["name"].Value;
                string expirationDate = matches[i].Groups["date"].Value;
                int calories = int.Parse(matches[i].Groups["calories"].Value);

                allCalories += calories;

                list.Add(new Food(name, expirationDate, calories));
            }

            Console.WriteLine($"You have food to last you for: {allCalories / 2000} days!");

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Food
    {
        public Food(string name, string expirationDate, int calories)
        {
            Name = name;
            ExpirationDate = expirationDate;
            Calories = calories;
        }

        public string Name { get; set; }
        public string ExpirationDate { get; set; }
        public int Calories { get; set; }

        public override string ToString()
            => $"Item: {Name}, Best before: {ExpirationDate}, Nutrition: {Calories}";
    }
}
