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

            var output = GetSoldProducts(context);

            Console.WriteLine(output);
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Count > 0)
                .Select(u => new UserDto()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    SoldProducts = u.ProductsSold
                        .Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price,
                        })
                        .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .ToArray();

            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var usersXml = new StringWriter())
            {
                serializer.Serialize(usersXml, users, ns);
                return usersXml.ToString();
            }
        }
    }
}