using System;

namespace _04.PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Pizza pizza;
            
			string[] pizzaData = Console.ReadLine().Split(" ");
            string pizzaName = pizzaData[1];
            
			try
			{
				pizza = new(pizzaName);
            }
			catch (Exception e)
			{
                Console.WriteLine(e.Message);
                return;
            }

            string[] doughData = Console.ReadLine().Split(" ");
            string flourType = doughData[1];
            string bakingTechnique = doughData[2];
            double doughWeight = double.Parse(doughData[3]);
            
            double calories = 0;
            
            try
            {
                Dough dough = new(flourType, bakingTechnique, doughWeight);
                calories += dough.GetDoughCalories();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            
            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] toppingData = command.Split(" ");
                string type = toppingData[1];
                double toppingWeight = double.Parse(toppingData[2]);
            
                try
                {
                    Topping topping = new(type, toppingWeight);
                    pizza.AddTopping(topping);
                    calories += topping.GetToppingCalories();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            
                command = Console.ReadLine();
            }

            Console.WriteLine($"{pizzaName} - {calories:f2} Calories.");
        }
    }
}
