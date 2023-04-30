using System.Collections.Generic;

namespace MilitaryElite.Interfaces
{
    public interface IEngineer : ISpecialisedSoldier
    {
        List<Repair> Repairs { get; }
    }
}
