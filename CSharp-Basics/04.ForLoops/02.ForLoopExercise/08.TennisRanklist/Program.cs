using System;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numTournaments = int.Parse(Console.ReadLine());
            int startPoints = int.Parse(Console.ReadLine());
            int points = startPoints;
            int averagePoints = 0;
            double winsPercent = 0;

            for (int i = 1; i <= numTournaments; i++)
            {

                string text = Console.ReadLine();

                if (text == "W")
                {
                    points += 2000;
                    winsPercent += 1;
                }
                else if (text == "F")
                {
                    points += 1200;
                }
                else if (text == "SF")
                {
                    points += 720;
                }
            }

            averagePoints = (points - startPoints) / numTournaments;
            winsPercent = (winsPercent / numTournaments) * 100;

            Console.WriteLine($"Final points: {points}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{winsPercent:f2}%");
        }
    }
}
