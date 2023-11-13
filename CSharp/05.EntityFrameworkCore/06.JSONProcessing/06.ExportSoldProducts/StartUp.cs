using System.Text.Json;
using ProductShop.Data;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var input = "users.json";
            var output = ImportUsers(context, input);

            Console.WriteLine(output);
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = File.ReadAllLines(inputJson);

            return string.Empty;
        }
    }
}