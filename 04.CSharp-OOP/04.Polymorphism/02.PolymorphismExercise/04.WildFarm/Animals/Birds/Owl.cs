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

        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().ToString() != "Meat")
            {
                throw new ArgumentException($"Owl does not eat {food.GetType()}!");
            }

            Weight += food.Quantity * 0.25;
        }
    }
}
