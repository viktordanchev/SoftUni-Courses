using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");

                people.Add(new Person() { Name = input[0], Age = int.Parse(input[1]) });
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = CreateFilter(condition, ageThreshold);
            Action<Person> printer = CreatePrinter(format);
            PrintFilteredPeople(people, filter, printer);
        }

        static void PrintFilteredPeople(List<Person> people, Func<Person, bool> filter, Action<Person> printer)
        {
            people = people.Where(p => filter(p)).ToList();

            foreach (Person person in people)
            {
                printer(person);
            }
        }

        static Action<Person> CreatePrinter(string format)
        {
            switch (format)
            {
                case "name":
                    return p => Console.WriteLine($"{p.Name}");
                case "age":
                    return p => Console.WriteLine($"{p.Age}");
                case "name age":
                    return p => Console.WriteLine($"{p.Name} - {p.Age}");
                default:
                    return null;
            }
        }

        static Func<Person, bool> CreateFilter(string condition, int ageThreshold)
        {
            switch (condition)
            {
                case "older":
                    return p => p.Age >= ageThreshold;
                case "younger":
                    return p => p.Age < ageThreshold;
                default:
                    return null;
            }
        }
    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}