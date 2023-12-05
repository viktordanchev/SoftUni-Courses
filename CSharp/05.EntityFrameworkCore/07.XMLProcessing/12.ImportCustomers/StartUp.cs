using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTOs.Import;
using System.Xml.Serialization;
using System.Linq;
using System.Globalization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var customersXml = File.ReadAllText(@"../../../Datasets/customers.xml");
            var output = ImportCustomers(context, customersXml);

            Console.WriteLine(output);
        }

        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("Customers"));
            var customerDtos = (CustomerDto[])serializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();

            foreach (var customerDto in customerDtos)
            {
                DateTime parsedBirthDate;
                var parseBirthDate = DateTime.TryParseExact(customerDto.BirthDate, "yyyy-MM-dd'T'HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedBirthDate);

                var customer = new Customer()
                {
                    Name = customerDto.Name,
                    BirthDate = parsedBirthDate,
                    IsYoungDriver = customerDto.IsYoungDriver
                };

                customers.Add(customer);
            }

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count}";
        }
    }
}