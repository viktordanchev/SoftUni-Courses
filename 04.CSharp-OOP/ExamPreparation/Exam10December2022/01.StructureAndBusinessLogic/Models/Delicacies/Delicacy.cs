using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
		private string name;
		private double price;

        protected Delicacy(string delicacyName, double price)
        {
            Name = delicacyName;
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
		public double Price
		{
			get { return price; }
			private set { price = value; }
		}

		public override string ToString()
		=> $"{Name} - {Price:f2} lv";

    }
}
