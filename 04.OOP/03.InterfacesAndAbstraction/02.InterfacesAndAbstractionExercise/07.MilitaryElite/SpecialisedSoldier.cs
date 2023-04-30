using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corps) 
            : base (id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps { get; }
    }
}
