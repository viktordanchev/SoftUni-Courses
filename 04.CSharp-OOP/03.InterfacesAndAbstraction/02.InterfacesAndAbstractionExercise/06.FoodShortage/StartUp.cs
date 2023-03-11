using _06.FoodShortage.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<IBuyer> society = new();

            int numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                switch (data.Length)
                {
                    case 3:
                        society.Add(new Rebel(data[0], int.Parse(data[1]), data[2]));
                        break;
                    case 4:
                        society.Add(new Citizens(data[0], int.Parse(data[1]), data[2], data[3]));
                        break;
                }
            }

            string name = Console.ReadLine();
            while (name != "End")
            {
                society.FirstOrDefault(p => p.Name == name)?.BuyFood();

                name = Console.ReadLine();
            }

            Console.WriteLine(society.Sum(p => p.Food));
        }
    }
}
