using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private ICollection<IGym> gyms;
        private List<string> validGymTypes = new List<string>() { "BoxingGym", "WeightliftingGym" };
        private List<string> validEquipmentTypes = new List<string>() { "BoxingGloves", "Kettlebell" };
        private List<string> validAthleteTypes = new List<string>() { "Boxer", "Weightlifter" };

        public Controller() 
        {
            equipment = new EquipmentRepository();
            gyms = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (!validAthleteTypes.Any(t => t == athleteType))
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);

            if (gym.GetType().Name == "BoxingGym" && athleteType == "Weightlifter" ||
                gym.GetType().Name == "WeightliftingGym" && athleteType == "Boxer")
                return string.Format(OutputMessages.InappropriateGym);

            IAthlete athlete = null;

            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
            }

            gym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            if (!validEquipmentTypes.Any(t => t == equipmentType))
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);

            IEquipment equipment = null;

            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipment = new BoxingGloves();
                    break;
                case "Kettlebell":
                    equipment = new Kettlebell();
                    break;
            }

            this.equipment.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        { 
            if (!validGymTypes.Any(t => t == gymType))
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);

            IGym gym = null;

            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    break;
                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    break;
            }

            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            if (equipment == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.FirstOrDefault(g => g.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
