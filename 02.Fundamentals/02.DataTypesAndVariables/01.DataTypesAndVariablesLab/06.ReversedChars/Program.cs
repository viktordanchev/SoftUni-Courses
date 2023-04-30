using System;

namespace _06.ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            char thirdChar = char.Parse(Console.ReadLine());

            Console.WriteLine($"{thirdChar} {secondChar} {firstChar}");
        }
    }
}
