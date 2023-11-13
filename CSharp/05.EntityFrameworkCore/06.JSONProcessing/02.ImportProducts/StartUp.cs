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

            var productsJson = File.ReadAllText(@"../../../Datasets/products.json");
            var output = ImportProducts(context, productsJson);

            Console.WriteLine(output);
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}