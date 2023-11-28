using _04.ImportCategoriesAndProducts.DTOs.Import;
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

            var inputXml = File.ReadAllText(@"../../../Datasets/categories-products.xml");
            var output = ImportCategoryProducts(context, inputXml);

            Console.WriteLine(output);
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CategoryProductDto[]), new XmlRootAttribute("CategoryProducts"));
            var categoryProductDtos = (CategoryProductDto[])serializer.Deserialize(new StringReader(inputXml));

            var validCategoryIds = context.Categories.Select(c => c.Id).ToList();
            var validProductIds = context.Products.Select(c => c.Id).ToList();

            var validCategoryProducts = new List<CategoryProduct>();
            foreach (var categoryProductDto in categoryProductDtos)
            {
                if(validCategoryIds.Contains(categoryProductDto.CategoryId) 
                    && validProductIds.Contains(categoryProductDto.ProductId)) 
                {
                    var validCategoryProduct = new CategoryProduct()
                    {
                        CategoryId = categoryProductDto.CategoryId,
                        ProductId = categoryProductDto.ProductId
                    };

                    validCategoryProducts.Add(validCategoryProduct);
                }
            }

            context.CategoryProducts.AddRange(validCategoryProducts);
            context.SaveChanges();

            return $"Successfully imported {validCategoryProducts.Count}";
        }
    }
}