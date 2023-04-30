using WildFarm.Foods;

namespace WildFarm.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        void Eat(Food food);
    }
}
