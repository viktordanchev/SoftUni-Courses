using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            Name = name;
            Budget = budget;
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);

                name = value;
            }
        }

        public double Budget
        {
            get { return budget; }
            private set 
            {
                if (value < 0)
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);

                budget = value;
            }
        }

        public double MilitaryPower
        {
            get 
            {
                double totalSum = Army.Sum(a => a.EnduranceLevel) + Weapons.Sum(w => w.DestructionLevel);

                if (Army.Any(a => a.GetType().Name == "AnonymousImpactUnit"))
                    totalSum += totalSum * 0.30;

                if (Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                    totalSum += totalSum * 0.45;

                return Math.Round(totalSum, 3);
            }
        }

        public IReadOnlyCollection<IMilitaryUnit> Army 
        { 
            get { return units.Models; } 
        }

        public IReadOnlyCollection<IWeapon> Weapons
        {
            get { return weapons.Models; }
        }

        public void AddUnit(IMilitaryUnit unit)
        {
            units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            List<string> armyList = Army.Select(a => a.GetType().Name).ToList();
            List<string> weaponsList = Weapons.Select(w => w.GetType().Name).ToList(); ;

            sb.AppendLine($"Planet: {Name}");
            sb.AppendLine($"--Budget: {Budget} billion QUID");

            if (Army.Count > 0)
                sb.AppendLine($"--Forces: {string.Join(", ", armyList)}");
            else
                sb.AppendLine("--Forces: No units");

            if (Weapons.Count > 0)
                sb.AppendLine($"--Combat equipment: {string.Join(", ", weaponsList)}");
            else
                sb.AppendLine($"--Combat equipment: No weapons");

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            Budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > Budget)
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);

            Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
