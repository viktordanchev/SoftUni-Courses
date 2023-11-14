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

            var output = GetUsersWithProducts(context);

            Console.WriteLine(output);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                .Select(u => new
                {
                    u.LastName,
                    u.Age,
                    SoldProducts = u.ProductsSold
                    .Select(ps => new
                    {
                        ps.Name,
                        ps.Price
                    })
                    .ToList()
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var usersJson = JsonConvert.SerializeObject(new
            {
                UsersCount = users.Length,
                Users = users.Select(u => new
                {
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        u.SoldProducts.Count,
                        Products = u.SoldProducts
                    }
                })
            }, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            });

            return usersJson;
        }
    }
}