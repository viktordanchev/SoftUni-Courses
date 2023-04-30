using System;
using System.Collections.Generic;

namespace _04.PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        private string Name 
        {
            get { return name; }
            set 
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            } 
        }

        private Dough Dough
        {
            get { return dough; }
            set { dough = value; }
        }

        private List<Topping> Toppings 
        {
            get { return toppings; }
            set { toppings = value; } 
        } 

        public void AddTopping(Topping topping)
        {
            if (Toppings.Count == 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            Toppings.Add(topping);
        }
    }
}
