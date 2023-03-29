using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private string size;
        private double price;

        protected Cocktail(string cocktailName, string size, double price)
        {
            Name = cocktailName;
            Size = size;
            Price = price;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

                name = value;
            }
        }
        public string Size
        {
            get { return size; }
            private set
            {
                if (value == "Small" || value == "Middle" || value == "Large")
                    size = value;
            }
        }
        public double Price
        {
            get { return price; }
            private set
            {
                if (Size == "Small")
                    price = value / 3;
                else if (Size == "Middle")
                    price = value - (value / 3);
                else
                    price = value;
            }
        }

        public override string ToString()
        => $"{Name} ({Size}) - {Price:f2} lv";
    }
}
