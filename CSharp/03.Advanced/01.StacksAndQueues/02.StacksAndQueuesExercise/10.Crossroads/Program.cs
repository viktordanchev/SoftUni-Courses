using System;

namespace _10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string text = "1 2 3 4 5 6";
            string currText = text.Substring(1, 5).Split(" ").ToString();

            Console.WriteLine(currText);
        }
    }
}
