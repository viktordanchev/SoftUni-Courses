using System;
using ExplicitInterfaces.Interfaces;

namespace ExplicitInterfaces
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; }
        public string Country { get; }
        public int Age { get; }

        string IResident.GetName()
        {
            return "Mr/Ms/Mrs";
        }

        string IPerson.GetName()
        {
            return Name;
        }
    }
}
