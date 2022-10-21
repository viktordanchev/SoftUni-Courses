using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfFoodForDogs = int.Parse(Console.ReadLine());
            int numberOfFoodForCats = int.Parse(Console.ReadLine());
            double priceForDogsFood = numberOfFoodForDogs * 2.50;
            int priceForCatsFood = numberOfFoodForCats * 4;
            double sumOfAll = priceForDogsFood + priceForCatsFood;
            Console.WriteLine($"{sumOfAll} lv.");
        }
    }
}
