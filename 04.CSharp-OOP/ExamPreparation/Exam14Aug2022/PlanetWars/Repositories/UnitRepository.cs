using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models
        {
            get { return militaryUnits.AsReadOnly(); }
        }

        public void AddItem(IMilitaryUnit model)
        {
            militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            return militaryUnits.FirstOrDefault(m => m.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return militaryUnits.Remove(FindByName(name));
        }
    }
}
