using AutoMapper;
using ProductShop.Data;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new ProductShopContext();

            var usersXml = File.ReadAllText(@"../../../Datasets/users.xml");
            var output = ImportUsers(context, usersXml);

            Console.WriteLine(output);
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(UserDto[]), new XmlRootAttribute("Users"));
            using var reader = new StringReader(inputXml);
            var userDTOs = serializer.Deserialize(reader);

            var mapper = new MapperConfiguration(c => c.AddProfile<ProductShopProfile>());
            var users = mapper.CreateMapper().Map<User[]>(userDTOs);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }
    }
}