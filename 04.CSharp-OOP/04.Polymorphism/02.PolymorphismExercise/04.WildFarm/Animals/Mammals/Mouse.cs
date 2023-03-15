using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            MakeSound();

            if (food.GetType().Name != "Fruit" && food.GetType().Name != "Vegetable")
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * 0.10;
            FoodEaten = food.Quantity;
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }
    }
}
