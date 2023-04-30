using System;

namespace _05.DateModifier
{
    public class Program
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int difference = DateModifier.GetDifference(firstDate, secondDate);

            Console.WriteLine(difference);
        }
    }
}