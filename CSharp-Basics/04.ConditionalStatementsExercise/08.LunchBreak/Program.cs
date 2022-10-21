using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int episodeDuration = int.Parse(Console.ReadLine());
            int restDuration = int.Parse(Console.ReadLine());

            double timeForLunch = restDuration * 1 / 8.0;
            double timeForRest = restDuration * 1 / 4.0;
            double timeLeft = restDuration - timeForLunch - timeForRest;

            if (timeLeft >= episodeDuration)
            {
                Console.WriteLine($"You have enough time to watch {name} and left with {Math.Ceiling(timeLeft - episodeDuration)} minutes free time.");
            }
            else
            {
                Console.WriteLine($"You don't have enough time to watch {name}, you need {Math.Ceiling(episodeDuration - timeLeft)} more minutes.");
            }
        }
    }
}
