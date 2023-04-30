using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _06.CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> firstHand = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> secondHand = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> powerfulHand = CheckWhichHandIsMorePowerful(firstHand, secondHand);
            int sum = GetSum(powerfulHand);

            if (firstHand.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
            
        }

        static int GetSum(List<int> powerfulHand)
        {
            int sum = 0;

            for (int i = 0; i < powerfulHand.Count; i++)
            {
                sum += powerfulHand[i];
            }

            return sum;
        }

        static List<int> CheckWhichHandIsMorePowerful(List<int> firstHand, List<int> secondHand)
        {
            while (firstHand.Count != 0 && secondHand.Count != 0)
            {
                if (firstHand[0] > secondHand[0])
                {
                    firstHand.Add(secondHand[0]);
                    firstHand.Add(firstHand[0]);
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
                else if (secondHand[0] > firstHand[0])
                {
                    secondHand.Add(firstHand[0]);
                    secondHand.Add(secondHand[0]);
                    secondHand.RemoveAt(0);
                    firstHand.RemoveAt(0);
                }
                else
                {
                    firstHand.RemoveAt(0);
                    secondHand.RemoveAt(0);
                }
            }

            if (firstHand.Count > 0)
            {
                return firstHand;
            }
            else
            {
                return secondHand;
            }
        }
    }
}
