using System;

namespace _01.ActionPrint
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printName = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            printName(names);
        }
    }
}