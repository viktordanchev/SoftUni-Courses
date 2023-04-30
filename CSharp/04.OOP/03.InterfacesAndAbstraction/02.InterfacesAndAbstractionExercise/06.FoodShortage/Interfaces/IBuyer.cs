namespace FoodShortage.Interfaces
{
    public interface IBuyer : INameable
    {
        int Food { get; }
        void BuyFood();
    }
}
