using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.ClimbThePeaks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> foodPortions = new(Console.ReadLine().Split(", ").Select(int.Parse));
            Queue<int> staminaQuantities = new(Console.ReadLine().Split(", ").Select(int.Parse));
            List<string> conqueredPeaks = new();
            Dictionary<string, int> peakByDifficultyLevel = new Dictionary<string, int>
            {
                ["Vihren"] = 80,
                ["Kutelo"] = 90,
                ["Banski Suhodol"] = 100,
                ["Polezhan"] = 60,
                ["Kamenitza"] = 70
            };

            int day = 1;
            bool didHeSucceed = false;

            while (day <= 7)
            {
                if (peakByDifficultyLevel.Count == 0)
                {
                    didHeSucceed = true;
                    break;
                }

                if (foodPortions.Count == 0)
                {
                    break;
                }

                int portion = foodPortions.Pop();
                int stamina = staminaQuantities.Dequeue();

                if (portion + stamina >= peakByDifficultyLevel.First().Value)
                {
                    conqueredPeaks.Add(peakByDifficultyLevel.First().Key);
                    peakByDifficultyLevel.Remove(peakByDifficultyLevel.First().Key);
                    continue;
                }

                day++;
            }

            if (didHeSucceed)
            {
                Console.WriteLine("Alex did it! He climbed all top five Pirin peaks in one week -> @FIVEinAWEEK");
            }
            else
            {
                Console.WriteLine("Alex failed! He has to organize his journey better next time -> @PIRINWINS");
            }

            if (conqueredPeaks.Count > 0)
            {
                Console.WriteLine("Conquered peaks:");
                Console.WriteLine(string.Join(Environment.NewLine, conqueredPeaks));
            }
        }
    }
}