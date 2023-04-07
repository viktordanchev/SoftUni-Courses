using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts)
            {
                for (int i = 0; i < planet.Items.Count; i++)
                {
                    string item = planet.Items.ToList()[i--];

                    astronaut.Breath();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);

                    if (!astronaut.CanBreath)
                        break;
                }
            }
        }
    }
}
