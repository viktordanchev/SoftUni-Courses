using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            ProduceSound();

            if (food.GetType().Name != "Meat" && food.GetType().Name != "Vegetable")
            {
                throw new ArgumentException($"Cat does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * 0.30;
            FoodEaten = food.Quantity;
        }

        protected override void ProduceSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
