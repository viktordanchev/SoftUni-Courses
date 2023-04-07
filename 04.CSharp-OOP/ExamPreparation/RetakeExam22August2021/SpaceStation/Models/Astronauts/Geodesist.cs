namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double GeodesistOxygen = 50;

        public Geodesist(string name) 
            : base(name, GeodesistOxygen)
        {
        }
    }
}
