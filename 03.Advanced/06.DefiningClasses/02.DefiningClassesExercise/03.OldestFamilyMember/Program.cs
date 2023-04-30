using System;

namespace DefiningClasses
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Family people = new Family();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(' ');

                Person person = new Person(data[0], int.Parse(data[1]));

                people.AddMember(person);
            }

            Console.WriteLine(people.GetOldestMember());
        }
    }
}