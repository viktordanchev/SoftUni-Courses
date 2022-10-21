using System;

namespace _01.Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int hour = 0; hour < 24; hour++)
            {
                for (int min = 0; min < 60; min++)
                {
                    Console.WriteLine($"{hour}:{min}");
                }
            }
        }
    }
}
