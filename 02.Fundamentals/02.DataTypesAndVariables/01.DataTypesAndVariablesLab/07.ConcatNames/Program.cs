using System;

namespace _07.ConcatNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstStr = Console.ReadLine();
            string secondStr = Console.ReadLine();
            string thirdStr = Console.ReadLine();

            Console.WriteLine($"{firstStr}{thirdStr}{secondStr}");
        }
    }
}
