using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int r = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            double income = 0;

            if (type == "Premiere")
            {
                income = 12;
            }
            else if (type == "Normal")
            {
                income = 7.5;
            }
            else
            {
                income = 5;
            }

            double area = r * c;
            double total = area * income;

            Console.WriteLine($"{total:f2}");
        }
    }
}
