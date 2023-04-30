using System;

namespace _07.WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int litersInTank = 0;

            for (int i = 1; i <= n; i++)
            {
                int quantitieOfWater = int.Parse(Console.ReadLine());
                litersInTank += quantitieOfWater;

                if (litersInTank > 255)
                {
                    Console.WriteLine("Insufficient capacity!");
                    litersInTank -= quantitieOfWater;
                    continue;
                }
            }

            Console.WriteLine(litersInTank);
        }
    }
}
