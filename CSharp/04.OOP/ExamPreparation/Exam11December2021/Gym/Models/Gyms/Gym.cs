using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;

        protected Gym(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Equipment = new List<IEquipment>();
            Athletes = new List<IAthlete>();
        }

        public string Name 
        { 
            get { return name; } 
            private set 
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException(ExceptionMessages.InvalidGymName);

                name = value; 
            }
        }

        public int Capacity { get; private set; }

        public double EquipmentWeight 
        {
            get
            {
                double value = 0;

                foreach (var equipment in Equipment)
                {
                    value += equipment.Weight;
                }

                return value;
            }
        }

        public ICollection<IEquipment> Equipment { get; private set; }

        public ICollection<IAthlete> Athletes { get; private set; }

        public void AddAthlete(IAthlete athlete)
        {
            if (Athletes.Count == Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);

            Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in Athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{Name} is a {GetType().Name}:");
            sb.Append("Athletes: ");

            if (Athletes.Count == 0)
                sb.AppendLine("No athletes");
            else
            {
                List<string> athletesNames = new List<string>();

                foreach (var athlete in Athletes)
                    athletesNames.Add(athlete.FullName);

                sb.AppendJoin(", ", athletesNames);
                sb.AppendLine();
            }

            sb.AppendLine($"Equipment total count: {Equipment.Count}");
            sb.AppendLine($"Equipment total weight: {EquipmentWeight:F2} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return Athletes.Remove(athlete);
        }
    }
}
