using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.EnergyDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> caffeinеsMg = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int currCaffeine = 0;

            while (caffeinеsMg.Count > 0 && energyDrinks.Count > 0)
            {
                int caffeinеMg = caffeinеsMg.Pop();
                int energyDrink = energyDrinks.Dequeue();

                if (currCaffeine + caffeinеMg * energyDrink <= 300)
                {
                    currCaffeine += caffeinеMg * energyDrink;
                }
                else
                {
                    energyDrinks.Enqueue(energyDrink);
                    currCaffeine -= 30;

                    if (currCaffeine < 0)
                    {
                        currCaffeine = 0;
                    }
                }
            }

            if (energyDrinks.Count > 0)
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {currCaffeine} mg caffeine.");
        }
    }
}