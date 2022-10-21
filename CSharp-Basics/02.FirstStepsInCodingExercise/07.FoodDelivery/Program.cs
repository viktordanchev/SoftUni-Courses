using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfChickenMenus = int.Parse(Console.ReadLine());
            int numberOfFishMenus = int.Parse(Console.ReadLine());
            int numberOfVegetarianMenus = int.Parse(Console.ReadLine());

            double priceForChickenMenu = numberOfChickenMenus * 10.35;
            double priceForFishMenu = numberOfFishMenus * 12.40;
            double priceForVegetarianMenu = numberOfVegetarianMenus * 8.15;
            double priceForAllProductsWithoutDessert = priceForChickenMenu + priceForFishMenu + priceForVegetarianMenu;
            double priceForDessert = priceForAllProductsWithoutDessert * (20 / 100.0);
            double totalSum = priceForAllProductsWithoutDessert + priceForDessert + 2.50;

            Console.WriteLine(totalSum);
        }
    }
}
