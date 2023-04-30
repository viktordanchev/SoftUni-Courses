using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private List<IRobot> models;

        public RobotRepository()
        {
            models = new List<IRobot>();
        }

        public void AddNew(IRobot model)
        {
            models.Add(model);
        }

        public IRobot FindByStandard(int interfaceStandard)
        {
            return models.FirstOrDefault(r => r.InterfaceStandards.Any(i => i == interfaceStandard));
        }

        public IReadOnlyCollection<IRobot> Models()
        {
            return models.AsReadOnly();
        }

        public bool RemoveByName(string typeName)
        {
            return models.Remove(models.First(r => r.Model == typeName));
        }
    }
}
