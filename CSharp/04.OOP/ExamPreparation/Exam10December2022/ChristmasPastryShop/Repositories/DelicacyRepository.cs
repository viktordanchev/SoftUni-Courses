using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private List<IDelicacy> delicacies = new List<IDelicacy>();

        public IReadOnlyCollection<IDelicacy> Models
        {
            get { return delicacies.AsReadOnly(); }
        }

        public void AddModel(IDelicacy model)
        {
            delicacies.Add(model);
        }
    }
}
