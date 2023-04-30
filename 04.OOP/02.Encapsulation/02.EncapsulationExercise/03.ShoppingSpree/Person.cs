using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bagOfProducts;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bagOfProducts = new List<Product>();
        }

        public decimal Money
        {
            get { return money; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }

        public void Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                bagOfProducts.Add(product);
                Console.WriteLine($"{Name} bought {product.Name}");
                Money -= product.Cost;
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }

        public override string ToString()
        {
            List<string> products = bagOfProducts.Select(p => p.Name).ToList();

            if (products.Count == 0)
            {
                return $"{Name} - Nothing bought";
            }

            return $"{Name} - {string.Join(", ", products)}";
        }
    }
}
