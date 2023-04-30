namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double BiologistOxygen = 70;

        public Biologist(string name) 
            : base(name, BiologistOxygen)
        {
        }

        public override void Breath()
        {
            if (Oxygen - 5 >= 0)
                Oxygen -= 5;
            else
                Oxygen = 0;
        }
    }
}
