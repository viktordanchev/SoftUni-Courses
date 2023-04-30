using System;

namespace _05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destination = Console.ReadLine();

            while (destination != "End")
            {
                double neededMoney = double.Parse(Console.ReadLine());

                double savings = 0;

                while (true)
                {
                    savings += double.Parse(Console.ReadLine());

                    if (savings >= neededMoney)
                    {
                        Console.WriteLine($"Going to {destination}!");
                        break;
                    }
                }

                destination = Console.ReadLine();
            }
        }
    }
}
