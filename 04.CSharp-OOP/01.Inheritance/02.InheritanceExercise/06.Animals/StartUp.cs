using System;
using System.Collections.Generic;
using Animals.Animals;
using Animals.Animals.Cats;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal animal;
            var animals = new List<Animal>();

            string input = Console.ReadLine();
            while (input != "Beast!")
            {
                string[] animalData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = animalData[0];
                int age = int.Parse(animalData[1]);
                string gender = animalData[2];

                try
                {
                    switch (input)
                    {
                        case "Cat":
                            animal = new Cat(name, age, gender);
                            break;
                        case "Dog":
                            animal = new Dog(name, age, gender);
                            break;
                        case "Frog":
                            animal = new Frog(name, age, gender);
                            break;
                        case "Tomcat":
                            animal = new Tomcat(name, age, gender);
                            break;
                        case "Kitten":
                            animal = new Kitten(name, age, gender);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");
                    }

                    animals.Add(animal);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                input = Console.ReadLine();
            }

            animals.ForEach(animal =>
            {
                Console.WriteLine(animal);
            });
        }
    }
}
