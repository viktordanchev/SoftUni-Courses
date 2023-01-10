using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int allSteps = 0;

            while (allSteps <= 10000)
            {
                string input = (Console.ReadLine());

                if (input == "Going home")
                {
                    int stepsForHome = int.Parse(Console.ReadLine());
                    allSteps += stepsForHome;
                    break;
                }
                int steps = int.Parse(input);
                allSteps += steps;
            }

            if (allSteps >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{allSteps - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - allSteps} more steps to reach goal.");
            }
        }
    }
}
