using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class SupplementRepository : IRepository<ISupplement>
    {
        private List<ISupplement> models;

        public SupplementRepository()
        {
            models = new List<ISupplement>();
        }

        public void AddNew(ISupplement model)
        {
            models.Add(model);
        }

        public ISupplement FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(s => s.InterfaceStandard == interfaceStandard);
        }

        public IReadOnlyCollection<ISupplement> Models()
        {
            return models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            return models.Remove(models.First(s => s.GetType().Name == typeName));
        }
    }
}
