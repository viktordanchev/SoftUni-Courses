using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        private List<string> validAstronautTypes = new List<string>() { "Biologist", "Geodesist", "Meteorologist" };
        private List<IPlanet> exploredPlanets = new List<IPlanet>();

        public Controller()
        {
            astronauts = new AstronautRepository();
            planets = new PlanetRepository();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (!validAstronautTypes.Any(t => t == type))
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);

            IAstronaut astronaut = null;

            switch (type)
            {
                case "Biologist":
                    astronaut = new Biologist(astronautName);
                    break;
                case "Geodesist":
                    astronaut = new Geodesist(astronautName);
                    break;
                case "Meteorologist":
                    astronaut = new Meteorologist(astronautName);
                    break;
            }

            astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);

            foreach (var item in items)
                planet.Items.Add(item);

            planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            List<IAstronaut> suitableAstronauts = astronauts.Models.Where(a => a.Oxygen > 60).ToList();

            if (suitableAstronauts.Count == 0)
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);

            Mission mission = new Mission();
            mission.Explore(planet, suitableAstronauts);
            exploredPlanets.Add(planet);

            int deadAstronauts = suitableAstronauts.Where(a => a.CanBreath == false).Count();

            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();   
                
            sb.AppendLine($"{exploredPlanets.Count} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = astronauts.FindByName(astronautName);

            if (astronaut == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));

            astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
