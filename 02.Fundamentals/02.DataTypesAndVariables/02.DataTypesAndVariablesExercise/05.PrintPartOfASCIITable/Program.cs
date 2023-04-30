using System;

namespace _05.PrintPartOfASCIITable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            for (int i = firstNum; i <= secondNum; i++)
            {
                char currChar = (char)i;
                Console.Write($"{currChar} ");
            }
        }
    }
}
