using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void Eat(Food food)
        {
            ProduceSound();

            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"Owl does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * 0.25;
            FoodEaten = food.Quantity;
        }

        protected override void ProduceSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
