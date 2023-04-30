using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BaristaContest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> coffeeQuantities = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> milkQuantities = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Dictionary<string, int> preparedDrinks = new Dictionary<string, int>();
            Dictionary<string, int> drinkByNeededQuantities = new Dictionary<string, int>
            {
                ["Cortado"] = 50,
                ["Espresso"] = 75,
                ["Capuccino"] = 100,
                ["Americano"] = 150,
                ["Latte"] = 200
            };

            while (coffeeQuantities.Count > 0 && milkQuantities.Count > 0)
            {
                bool isNotEqualToAny = false;

                int coffeeQuantity = coffeeQuantities.Dequeue();
                int milkQuantity = milkQuantities.Pop();

                foreach (var drink in drinkByNeededQuantities)
                {
                    if (coffeeQuantity + milkQuantity == drink.Value)
                    {
                        isNotEqualToAny = true;

                        if (!preparedDrinks.ContainsKey(drink.Key))
                        {
                            preparedDrinks.Add(drink.Key, 1);
                            continue;
                        }

                        preparedDrinks[drink.Key]++;
                    }
                }

                if (!isNotEqualToAny)
                {
                    milkQuantity -= 5;
                    milkQuantities.Push(milkQuantity);
                }
            }

            if (milkQuantities.Count == 0 && coffeeQuantities.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");

                if (coffeeQuantities.Count > 0)
                {
                    Console.WriteLine($"Coffee left: {string.Join(", ", coffeeQuantities)}");
                    Console.WriteLine("Milk left: none");
                }

                if (milkQuantities.Count > 0)
                {
                    Console.WriteLine("Coffee left: none");
                    Console.WriteLine($"Milk left: {string.Join(", ", milkQuantities)}");
                }
            }

            preparedDrinks = preparedDrinks.OrderBy(dr => dr.Value).ThenByDescending(dr => dr.Key)
                .ToDictionary(dr => dr.Key, dr => dr.Value);

            foreach (var drink in preparedDrinks)
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }
    }
}
