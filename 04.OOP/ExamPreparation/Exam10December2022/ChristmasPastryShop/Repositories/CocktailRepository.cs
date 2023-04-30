using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using System.Collections.Generic;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private List<ICocktail> cocktails = new List<ICocktail>();

        public IReadOnlyCollection<ICocktail> Models
        {
            get { return cocktails.AsReadOnly(); }
        }

        public void AddModel(ICocktail model)
        {
            cocktails.Add(model);
        }
    }
}
