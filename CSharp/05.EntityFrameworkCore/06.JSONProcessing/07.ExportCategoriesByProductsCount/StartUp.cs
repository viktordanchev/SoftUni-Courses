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

            var output = GetCategoriesByProductsCount(context);

            Console.WriteLine(output);
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category = c.Name,
                    ProductsCount = c.CategoriesProducts.Count,
                    AveragePrice = $"{c.CategoriesProducts.Average(c => c.Product.Price):F2}",
                    TotalRevenue = $"{c.CategoriesProducts.Count * c.CategoriesProducts.Average(c => c.Product.Price):F2}"
                })
                .ToArray()
                .OrderByDescending(c => c.ProductsCount);

            DefaultContractResolver contractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };

            var categoriesJson = JsonConvert.SerializeObject(categories, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return categoriesJson;
        }
    }
}