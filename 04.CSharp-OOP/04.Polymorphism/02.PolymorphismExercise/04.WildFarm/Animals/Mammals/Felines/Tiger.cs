using System;
using WildFarm.Foods;

namespace WildFarm.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
            Console.WriteLine("ROAR!!!");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().ToString() != "Meat")
            {
                throw new ArgumentException($"Tiger does not eat {food.GetType()}!");
            }

            Weight += food.Quantity * 1;
            MakeSound();
        }

        protected override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
