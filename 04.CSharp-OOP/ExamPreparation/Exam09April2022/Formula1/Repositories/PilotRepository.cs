using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models;

        public PilotRepository()
        {
            models = new List<IPilot>();
        }

        public IReadOnlyCollection<IPilot> Models
        {
            get { return models.AsReadOnly(); }
        }

        public void Add(IPilot model)
        {
            models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return models.FirstOrDefault(p => p.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return models.Remove(model);
        }
    }
}
