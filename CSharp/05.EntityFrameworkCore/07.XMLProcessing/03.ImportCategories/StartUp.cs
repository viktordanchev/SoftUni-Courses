using ProductShop.DTOs.Import;
using AutoMapper;
using ProductShop.Data;
using System.Xml.Serialization;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var inputXml = File.ReadAllText(@"../../../Datasets/categories.xml");
            var output = ImportCategories(context, inputXml);

            Console.WriteLine(output);
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            var categoryDtos = serializer.Deserialize(new StringReader(inputXml));

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var categories = mapper.CreateMapper().Map<Category[]>(categoryDtos);

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }
    }
}