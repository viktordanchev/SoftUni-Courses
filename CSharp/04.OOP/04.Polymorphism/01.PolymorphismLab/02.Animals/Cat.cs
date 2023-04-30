namespace Animals
{
    public class Cat : Animal
    {
        public Cat(string name, string favouriteFood) 
            : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
        => $"I am {Name} and my fovourite food is {FavouriteFood} MEEOW";
    }
}
