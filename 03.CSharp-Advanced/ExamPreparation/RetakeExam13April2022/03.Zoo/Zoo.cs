using System.Collections.Generic;

namespace Zoo
{
    public class Zoo
    {
        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public List<Animal> Animals { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal)
        {
            if (animal.Species == null || animal.Species == " ")
            {
                return "Invalid animal species.";
            }

            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }

            if (animal.Diet == "herbivore" || animal.Diet == "carnivore")
            {
                Animals.Add(animal);
                return $"Successfully added {animal.Species} to the zoo.";
            }
            else
            {
                return "Invalid animal diet.";
            }
        }

        public int RemoveAnimals(string species)
        {
            int removed = 0;

            for (int i = 0; i < Animals.Count; i++)
            {
                if (Animals[i].Species == species)
                {
                    Animals.RemoveAt(i--);
                    removed++;
                }
            }

            return removed;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            List<Animal> list = new List<Animal>();

            foreach (var animal in Animals)
            {
                if (animal.Diet == diet)
                {
                    list.Add(animal);
                }
            }

            return list;
        }

        public Animal GetAnimalByWeight(double weight)
        {
            foreach (var animal in Animals)
            {
                if (animal.Weight == weight)
                {
                    return animal;
                }
            }

            return null;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;

            foreach (var animal in Animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }
            }

            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}