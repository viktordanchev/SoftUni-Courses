using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
        {
            get { return weapons.AsReadOnly(); }
        }

        public void AddItem(IWeapon model)
        {
            weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return weapons.FirstOrDefault(w => w.GetType().Name == name);
        }

        public bool RemoveItem(string name)
        {
            return weapons.Remove(FindByName(name));
        }
    }
}
