using System;

namespace _08.TriangleOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int lines = 1; lines <= num; lines++)
            {
                Console.WriteLine();
                for (int i = 1; i <= lines; i++)
                {
                    Console.Write($"{lines} ");
                }
            }
        }
    }
}
