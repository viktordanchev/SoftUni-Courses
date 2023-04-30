using System;

namespace _02.Password
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            string pass = Console.ReadLine();
            string passAtempt = Console.ReadLine();

            while (passAtempt != pass)
            {
                passAtempt = Console.ReadLine();
            }

            if (passAtempt == pass)
            {
                Console.WriteLine($"Welcome {name}!");
            }
        }
    }
}
