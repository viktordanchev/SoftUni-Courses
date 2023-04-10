using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace _03.BakeryShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Food> list = new List<Food>();
            int allSoldFood = 0;
            string input = Console.ReadLine();

            while (input != "Complete")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = data[0];
                int quantity = int.Parse(data[1]);
                string name = data[2];

                switch (command)
                {
                    case "Receive":
                        if (quantity <= 0)
                        {
                            input = Console.ReadLine();
                            continue;
                        }

                        Food food = list.FirstOrDefault(x => x.Name == name);

                        if (food == null)
                        {
                            food = new Food(name, quantity);
                            list.Add(food);
                        }
                        else
                            food.Quantity += quantity;
                        break;
                    case "Sell":
                        food = list.FirstOrDefault(x => x.Name == name);

                        if (food == null)
                        {
                            Console.WriteLine($"You do not have any {name}.");
                        }
                        else if (food.Quantity < quantity)
                        {
                            Console.WriteLine($"There aren't enough {name}. You sold the last {food.Quantity} of them.");

                            allSoldFood += food.Quantity;
                            list.Remove(food);
                        }
                        else
                        {
                            food.Quantity -= quantity;
                            Console.WriteLine($"You sold {quantity} {name}.");

                            allSoldFood += quantity;
                            if (food.Quantity == 0)
                                list.Remove(food);
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            foreach (var food in list)
            {
                Console.WriteLine(food);
            }

            Console.WriteLine($"All sold: {allSoldFood} goods");
        }
    }

    class Food
    {
        public Food(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
            => $"{Name}: {Quantity}";
    }
}
