using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;
        private List<string> allowedMilitaryUnits = new List<string>() { "AnonymousImpactUnit", "SpaceForces", "StormTroopers" };
        private List<string> allowedWeapons = new List<string>() { "BioChemicalWeapon", "NuclearWeapon", "SpaceMissiles" };

        public Controller()
        {
            planets = new PlanetRepository();
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planets.FindByName(planetName) == null)
                return string.Format(ExceptionMessages.UnexistingPlanet, planetName);

            if (!allowedMilitaryUnits.Any(t => t == unitTypeName))
                return string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName);

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Army.Any(a => a.GetType().Name == unitTypeName))
                return string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName);

            IMilitaryUnit unit = null;
            switch (unitTypeName)
            {
                case "AnonymousImpactUnit":
                    unit = new AnonymousImpactUnit();
                    break;
                case "SpaceForces":
                    unit = new SpaceForces();
                    break;
                case "StormTroopers":
                    unit = new StormTroopers();
                    break;
            }

            if (unit.Cost < planet.Budget)
                planet.AddUnit(unit);

            planet.Spend(unit.Cost);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planets.FindByName(planetName) == null)
                return string.Format(ExceptionMessages.UnexistingPlanet, planetName);

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Weapons.Any(a => a.GetType().Name == weaponTypeName))
                return string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName);

            if (!allowedWeapons.Any(w => w == weaponTypeName))
                return string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName);

            IWeapon weapon = null;
            switch (weaponTypeName)
            {
                case "BioChemicalWeapon":
                    weapon = new BioChemicalWeapon(destructionLevel);
                    break;
                case "NuclearWeapon":
                    weapon = new NuclearWeapon(destructionLevel);
                    break;
                case "SpaceMissiles":
                    weapon = new SpaceMissiles(destructionLevel);
                    break;
            }

            if (weapon.Price < planet.Budget)
                planet.AddWeapon(weapon);
            
            planet.Spend(weapon.Price);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {
            if (planets.FindByName(name) != null)
                return string.Format(OutputMessages.ExistingPlanet, name);

            planets.AddItem(new Planet(name, budget));
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            List<IPlanet> orderedPlanets = planets.Models
                .OrderByDescending(p => p.MilitaryPower)
                .ThenBy(p => p.Name)
                .ToList();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");

            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().Trim();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);
            IPlanet winnerPlanet = null;
            IPlanet losingPlanet = null;

            if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winnerPlanet = firstPlanet;
                losingPlanet = secondPlanet;
            }
            else if (firstPlanet.MilitaryPower < secondPlanet.MilitaryPower)
            {
                winnerPlanet = secondPlanet;
                losingPlanet = firstPlanet;
            }
            else
            {
                if (firstPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winnerPlanet = firstPlanet;
                    losingPlanet = secondPlanet;
                }
                else if (secondPlanet.Weapons.Any(w => w.GetType().Name == "NuclearWeapon"))
                {
                    winnerPlanet = secondPlanet;
                    losingPlanet = firstPlanet;
                }
                else
                    return string.Format(OutputMessages.NoWinner);
            }

            winnerPlanet.Spend(winnerPlanet.Budget / 2);
            winnerPlanet.Profit(losingPlanet.Budget / 2);

            double amount = 0;

            foreach (var unit in losingPlanet.Army)
            {
                amount += unit.Cost;
            }

            foreach (var weapon in losingPlanet.Weapons)
            {
                amount += weapon.Price;
            }

            winnerPlanet.Profit(amount);
            planets.RemoveItem(losingPlanet.Name);

            return string.Format(OutputMessages.WinnigTheWar, winnerPlanet.Name, losingPlanet.Name);
        }

        public string SpecializeForces(string planetName)
        {
            if (planets.FindByName(planetName) == null)
                return string.Format(ExceptionMessages.UnexistingPlanet, planetName);

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Army.Count == 0)
                return string.Format(ExceptionMessages.NoUnitsFound);

            planet.Spend(1.25);
            planet.TrainArmy();

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
