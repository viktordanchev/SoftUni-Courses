using System;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string> printName = n => Console.WriteLine(n);

            foreach (var name in names)
            {
                printName(name);
            }
        }
    }
}