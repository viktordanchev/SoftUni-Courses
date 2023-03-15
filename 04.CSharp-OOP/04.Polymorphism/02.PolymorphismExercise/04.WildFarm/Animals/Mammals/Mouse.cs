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

        public override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().ToString() != "Fruit" && food.GetType().ToString() != "Vegetables")
            {
                throw new ArgumentException($"Mouse does not eat {food.GetType()}!");
            }

            Weight += food.Quantity * 0.10;
        }
    }
}
