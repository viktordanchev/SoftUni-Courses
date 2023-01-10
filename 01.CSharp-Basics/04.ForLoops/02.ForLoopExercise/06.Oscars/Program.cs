using System;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double points = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                string jury = Console.ReadLine();
                double juryPoints = double.Parse(Console.ReadLine());

                points = points + ((jury.Length * juryPoints) / 2);

                if (points >= 1250.5)
                {
                    Console.WriteLine($"Congratulations, {name} got a nominee for leading role with {points:f1}!");
                    break;
                }

            }

            if (points < 1250.5)
            {
                Console.WriteLine($"Sorry, {name} you need {1250.5 - points:f1} more!");
            }
        }
    }
}
