using _04.BorderControl.Interfaces;
using System;
using System.Collections.Generic;

namespace _04.BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<IIdentifiable> society = new();

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (data.Length)
                {
                    case 2:
                        society.Add(new Robot(data[0], data[1]));
                        break;
                    case 3:
                        society.Add(new Citizens(data[0], int.Parse(data[1]), data[2]));
                        break;
                }

                command = Console.ReadLine();
            }

            string invalidIdsSuffix = Console.ReadLine();

            foreach (var person in society)
            {
                if (person.Id.Substring(person.Id.Length - invalidIdsSuffix.Length) == invalidIdsSuffix)
                {
                    Console.WriteLine(person.Id);
                }
            }
        }
    }
}
