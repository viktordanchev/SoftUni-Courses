using ProductShop.DTOs.Export;
using ProductShop.Data;
using System.Xml.Serialization;

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
                .Select(c => new CategoryDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Average(p => p.Product.Price),
                    TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price)
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categroies"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using(var categoriesXml = new StringWriter())
            {
                serializer.Serialize(categoriesXml, categories, ns);
                return categoriesXml.ToString();
            }
        }
    }
}