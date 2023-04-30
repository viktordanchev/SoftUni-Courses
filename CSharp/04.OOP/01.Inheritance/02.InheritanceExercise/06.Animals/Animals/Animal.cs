using System;

namespace Animals.Animals
{
    public abstract class Animal
    {
        private string name;
        private int age;
        private string gender;

        protected Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }

        public string Name 
        { 
            get => name;
            set 
            { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid input!");

                name = value;
            }
        }
        public int Age 
        {
            get => age;
            set 
            {
                if (value <= 0)
                    throw new ArgumentException("Invalid input!");

                age = value;
            }
        }
        public string Gender
        {
            get => gender;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Invalid input!");

                gender = value;
            }
        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name}" + Environment.NewLine + 
                $"{Name} {Age} {Gender}" + Environment.NewLine + 
                $"{ProduceSound()}";
        }
    }
}
