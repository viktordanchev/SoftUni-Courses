namespace PlanetWars.Models.MilitaryUnits
{
    public class StormTroopers : MilitaryUnit
    {
        private const double StormTroopersCost = 2.5; 

        public StormTroopers() 
            : base(StormTroopersCost)
        {
        }
    }
}
