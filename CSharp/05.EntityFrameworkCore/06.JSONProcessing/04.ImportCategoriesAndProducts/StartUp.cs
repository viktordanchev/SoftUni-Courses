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

            var categoriesProductsJson = File.ReadAllText(@"../../../Datasets/categories-products.json");
            var output = ImportCategoryProducts(context, categoriesProductsJson);

            Console.WriteLine(output);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoriesProducts.AddRange(categoriesProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }
    }
}