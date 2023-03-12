using ExplicitInterfaces.Interfaces;
using System;
using System.Collections.Generic;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Citizen> citizens = new();
            
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Citizen citizen = new(data[0], data[1], int.Parse(data[2]));
                citizens.Add(citizen);

                input = Console.ReadLine();
            }

            foreach (var citizen in citizens)
            {
                IResident resident = citizen;
                IPerson person = citizen;

                Console.WriteLine(person.GetName());
                Console.WriteLine($"{resident.GetName()} {person.GetName()}");
            }
        }
    }
}
