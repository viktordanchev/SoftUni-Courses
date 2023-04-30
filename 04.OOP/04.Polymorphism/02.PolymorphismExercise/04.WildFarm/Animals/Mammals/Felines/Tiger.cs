using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override void Eat(Food food)
        {
            ProduceSound();

            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"Tiger does not eat {food.GetType().Name}!");
            }

            Weight += food.Quantity * 1;
            FoodEaten = food.Quantity;
        }

        protected override void ProduceSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
