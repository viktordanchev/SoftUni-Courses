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

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().ToString() != "Meat" && food.GetType().ToString() != "Vegetables")
            {
                throw new ArgumentException($"Cat does not eat {food.GetType()}!");
            }

            Weight += food.Quantity * 0.30;
        }
    }
}
