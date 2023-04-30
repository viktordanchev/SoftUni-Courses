namespace PlanetWars.Models.MilitaryUnits
{
    public class SpaceForces : MilitaryUnit
    {
        private const double SpaceForcesCost = 11;

        public SpaceForces() 
            : base(SpaceForcesCost)
        {
        }
    }
}
