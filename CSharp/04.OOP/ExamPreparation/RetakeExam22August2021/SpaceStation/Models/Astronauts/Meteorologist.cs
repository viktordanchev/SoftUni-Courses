namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double MeteorologistOxygen = 90;

        public Meteorologist(string name) 
            : base(name, MeteorologistOxygen)
        {
        }
    }
}
