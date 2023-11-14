using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var output = GetSoldProducts(context);

            Console.WriteLine(output);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                        BuyerFirstName = p.Buyer.FirstName,
                        BuyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .Where(u => u.SoldProducts.Count > 0)
                .ToArray()
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName);

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var usersJson = JsonConvert.SerializeObject(users, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return usersJson;
        }
    }
}