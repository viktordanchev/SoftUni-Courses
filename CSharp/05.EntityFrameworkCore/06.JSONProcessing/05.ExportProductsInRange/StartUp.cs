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

            var output = GetProductsInRange(context);

            Console.WriteLine(output);
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Select(p => new
                {
                    p.Name,
                    p.Price,
                    Seller = p.Seller.FirstName + " " + p.Seller.LastName
                })
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .ToArray()
                .OrderBy(p => p.Price);

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var productsJson = JsonConvert.SerializeObject(products, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return productsJson;
        }
    }
}