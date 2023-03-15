using WildFarm.Foods;
using WildFarm.Interfaces;

namespace WildFarm.Animals
{
    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }
        public double Weight { get; protected set; }
        public int FoodEaten { get; }
        protected abstract void MakeSound();
        public abstract void Eat(Food food);
    }
}
