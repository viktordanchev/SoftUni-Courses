using System;

namespace _04.InchesToCentimeters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inches = double.Parse(Console.ReadLine());
            Console.WriteLine(inches * 2.54);
        }
    }
}
