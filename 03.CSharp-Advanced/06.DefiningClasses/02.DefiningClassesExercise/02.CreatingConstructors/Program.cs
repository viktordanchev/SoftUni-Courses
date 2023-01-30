using System;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person person = new Person("pesho", 23);
            Console.WriteLine($"{person.Name} - {person.Age}");
        }
    }
}
