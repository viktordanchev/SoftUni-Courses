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
        public int FoodEaten { get; protected set; }
        protected abstract void ProduceSound();
        public abstract void Eat(Food food);
    }
}
