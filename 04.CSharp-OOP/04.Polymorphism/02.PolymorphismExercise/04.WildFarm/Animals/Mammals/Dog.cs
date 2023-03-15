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
            if (food.GetType().ToString() != "Meat")
            {
                throw new ArgumentException($"Dog does not eat {food.GetType()}!");
            }

            Weight += food.Quantity * 0.40;
            MakeSound();
        }

        protected override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
    }
}
