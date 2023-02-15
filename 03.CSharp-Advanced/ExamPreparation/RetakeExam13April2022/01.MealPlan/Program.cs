using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.MealPlan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mealByCalories = new Dictionary<string, int>()
            {
                ["salad"] = 350,
                ["soup"] = 490,
                ["pasta"] = 680,
                ["steak"] = 790
            };

            Queue<string> meals = new Queue<string>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries));
            int numberOfMeals = meals.Count;

            Stack<int> caloriesForDays = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int mealCalories = 0;
            while (meals.Count > 0 && caloriesForDays.Count > 0)
            {
                string meal = meals.Peek();
                if (mealCalories == 0)
                {
                    mealCalories = GetCaloriesForCurrMeal(mealByCalories, meal);
                }
                int dailyCalories = caloriesForDays.Pop();
                
                if (dailyCalories - mealCalories > 0)
                {
                    meals.Dequeue();
                    dailyCalories -= mealCalories;
                    caloriesForDays.Push(dailyCalories);
                    mealCalories = 0;
                    continue;
                }

                mealCalories -= dailyCalories;

                if (caloriesForDays.Count == 0)
                {
                    meals.Dequeue();
                    break;
                }
            }

            if (meals.Count == 0)
            {
                Console.WriteLine($"John had {numberOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", caloriesForDays)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numberOfMeals - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }

        static int GetCaloriesForCurrMeal(Dictionary<string, int> mealByCalories, string meal)
        {
            foreach (var currMeal in mealByCalories)
            {
                if (currMeal.Key == meal)
                {
                    return currMeal.Value;
                }
            }

            return 0;
        }
    }
}