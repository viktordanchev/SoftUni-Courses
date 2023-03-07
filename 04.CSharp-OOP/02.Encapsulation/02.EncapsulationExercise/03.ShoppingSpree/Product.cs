using System;

namespace _03.ShoppingSpree
{
    public class Product
    {
		private string name;
		private decimal cost;

        public Product(string name, decimal cost)
        {
			Name = name;
			Cost = cost;
        }

        public decimal Cost
		{
			get { return cost; }
			set { cost = value; }
		}

		public string Name
		{
			get { return name; }
			set
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}

				name = value; 
			}
		}
	}
}
