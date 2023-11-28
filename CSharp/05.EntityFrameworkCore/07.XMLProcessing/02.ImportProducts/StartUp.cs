using _02.ImportProducts.DTOs.Import;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var inputXml = File.ReadAllText(@"../../../Datasets/products.xml");
            var output = ImportProducts(context, inputXml);

            Console.WriteLine(output);
        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(ProductDto[]), new XmlRootAttribute("Products"));
            var productDtos = serializer.Deserialize(new StringReader(inputXml));

            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<ProductShopProfile>());
            var products = mapper.CreateMapper().Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
    }
}