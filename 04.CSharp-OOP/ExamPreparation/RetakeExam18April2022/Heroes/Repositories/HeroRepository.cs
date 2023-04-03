using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Heroes.Repositories
{
    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models = new List<IHero>();

        public IReadOnlyCollection<IHero> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IHero model)
        {
            models.Add(model);
        }

        public IHero FindByName(string name)
        {
            return models.FirstOrDefault(h => h.Name == name);
        }

        public bool Remove(IHero model)
        {
            return models.Remove(model);
        }
    }
}
