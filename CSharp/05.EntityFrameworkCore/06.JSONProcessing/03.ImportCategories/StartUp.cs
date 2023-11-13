using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var categoriesJson = File.ReadAllText(@"../../../Datasets/categories.json");
            var output = ImportCategories(context, categoriesJson);

            Console.WriteLine(output);
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson);
            var validCategories = categories
                .Where(c => c.Name != null)
                .ToArray();

            if (validCategories.Length > 0)
            {
                context.AddRange(validCategories);
                context.SaveChanges();
            }

            return $"Successfully imported {validCategories.Length}";
        }
    }
}