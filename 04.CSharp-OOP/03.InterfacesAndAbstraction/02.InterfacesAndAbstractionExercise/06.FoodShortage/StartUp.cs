using _05.BirthdayCelebrations.Interfaces;
using System;
using System.Collections.Generic;

namespace _05.BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<IBirthable> society = new();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (data[0])
                {
                    case "Citizen":
                        society.Add(new Citizens(data[1], int.Parse(data[2]), data[3], data[4]));
                        break;
                    case "Pet":
                        society.Add(new Pet(data[1], data[2]));
                        break;
                }

                command = Console.ReadLine();
            }

            string specialYear = Console.ReadLine();

            foreach (var person in society)
            {
                if (person.Birthdate.Substring(person.Birthdate.Length - specialYear.Length) == specialYear)
                {
                    Console.WriteLine(person.Birthdate);
                }
            }
        }
    }
}
