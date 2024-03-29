﻿namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            Name = name;
            FavouriteFood = favouriteFood;
        }

        public string Name { get; }
        public string FavouriteFood { get; }

        public virtual string ExplainSelf()
        => $"I am {Name} and my fovourite food is {FavouriteFood}";
    }
}
