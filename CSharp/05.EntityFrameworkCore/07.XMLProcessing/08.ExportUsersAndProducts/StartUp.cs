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

            var output = GetUsersWithProducts(context);

            Console.WriteLine(output);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .Take(10)
                        .ToArray()
                    }
                })
                .OrderByDescending(u => u.SoldProducts.Count)
                .ToArray();

            var usersDto = new UsersDto()
            {
                Count = users.Length,
                Users = users
            };

            var serializer = new XmlSerializer(typeof(UsersDto), new XmlRootAttribute("Users"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var usersXml = new StringWriter())
            {
                serializer.Serialize(usersXml, usersDto, ns);
                return usersXml.ToString();
            }
        }
    }
}