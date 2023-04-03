using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models = new List<IWeapon>();

        public IReadOnlyCollection<IWeapon> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(w => w.Name == name);
        }

        public bool Remove(IWeapon model)
        {
            return models.Remove(model);
        }
    }
}
