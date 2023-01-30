using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
 
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(' ');

                Person person = new Person(data[0], int.Parse(data[1]));

                people.Add(person);
            }

            List<Person> oldestPeople = new List<Person>();

            foreach (Person person in people)
            {
                if (person.Age > 30)
                {
                    oldestPeople.Add(person);
                }
            }

            oldestPeople = oldestPeople.OrderBy(p => p.Name).ToList();

            foreach (Person person in oldestPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}