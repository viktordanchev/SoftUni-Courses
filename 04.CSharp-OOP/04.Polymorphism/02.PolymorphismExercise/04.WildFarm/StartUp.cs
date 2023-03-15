using System;
using System.Collections.Generic;
using WildFarm.Animals;
using WildFarm.Animals.Birds;
using WildFarm.Animals.Mammals;
using WildFarm.Animals.Mammals.Felines;
using WildFarm.Foods;

namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] animalData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string animalType = animalData[0];

                string[] foodData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string foodType = animalData[0];

                Animal animal = null;
                switch (animalType)
                {
                    case "Owl":
                        animal = new Owl(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
                        break;
                    case "Hen":
                        animal = new Hen(animalData[1], double.Parse(animalData[2]), double.Parse(animalData[3]));
                        break;
                    case "Mouse":
                        animal = new Mouse(animalData[1], double.Parse(animalData[2]), animalData[3]);
                        break;
                    case "Dog":
                        animal = new Dog(animalData[1], double.Parse(animalData[2]), animalData[3]);
                        break;
                    case "Cat":
                        animal = new Cat(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
                        break;
                    case "Tiger":
                        animal = new Tiger(animalData[1], double.Parse(animalData[2]), animalData[3], animalData[4]);
                        break;
                }

                Food food = null;
                switch (foodType)
                {
                    case "Fruit": food = new Fruit(int.Parse(foodData[1])); break;
                    case "Meat": food = new Meat(int.Parse(foodData[1])); break;
                    case "Seeds": food = new Seeds(int.Parse(foodData[1])); break;
                    case "Vegetable": food = new Vegetable(int.Parse(foodData[1])); break;
                }

                animals.Add(animal);
                animal.MakeSound();

                try
                {
                    animal.Eat(food);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }


                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.ToString());
            }
        }
    }
}
