using System;
using System.Runtime.InteropServices;

namespace _06.TriplesOfLatinLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                char firstChar = (char)('a' + i);

                for (int k = 0; k < number; k++)
                {
                    char secondChar = (char)('a' + k);

                    for (int j = 0; j < number; j++)
                    {
                        char thirdChar = (char)('a' + j);

                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}
