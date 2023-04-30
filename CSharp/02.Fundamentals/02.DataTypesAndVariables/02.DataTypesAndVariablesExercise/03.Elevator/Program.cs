using System;

namespace _03.Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int peoples = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = (int)Math.Ceiling((double)peoples / capacity);

            Console.WriteLine(courses);
        }
    }
}
