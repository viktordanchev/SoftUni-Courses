using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        public override void Eat(Food food)
        {
            MakeSound();

            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"Dog does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * 0.40;
            FoodEaten = food.Quantity;
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
