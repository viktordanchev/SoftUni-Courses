namespace Animals
{
    public class Dog : Animal
    {
        public Dog(string name, string favouriteFood) : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        => $"I am {Name} and my fovourite food is {FavouriteFood} DJAAF";
    }
}
