using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        { 
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(Food food)
        {
            Weight += food.Quantity * 0.35;
        }
    }
}
