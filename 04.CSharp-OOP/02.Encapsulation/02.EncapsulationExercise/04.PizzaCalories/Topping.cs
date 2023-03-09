using System;

namespace _04.PizzaCalories
{
    public class Topping
    {
        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;

		private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;
        }

        private string Type
		{
			get { return type; }
			set 
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" &&
                    value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value; 
            }
		}

        private double Weight
        {
            get { return weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double GetToppingCalories()
        {
            double calories = 0;

            switch (Type.ToLower())
            {
                case "meat":
                    calories = 2 * Weight * Meat;
                    break;
                case "veggies":
                    calories = 2 * Weight * Veggies;
                    break;
                case "cheese":
                    calories = 2 * Weight * Cheese;
                    break;
                case "sauce":
                    calories = 2 * Weight * Sauce;
                    break;
            }

            return calories;
        }
    }
}
