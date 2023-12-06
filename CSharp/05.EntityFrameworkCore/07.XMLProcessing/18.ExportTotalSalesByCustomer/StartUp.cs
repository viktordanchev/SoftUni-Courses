using CarDealer.Data;
using CarDealer.DTOs.Export;
using Microsoft.EntityFrameworkCore;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var output = GetTotalSalesByCustomer(context);

            Console.WriteLine(output);
        }

        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Include(c => c.Sales)
                .ThenInclude(s => s.Car.PartsCars)
                .ThenInclude(p => p.Part)
                .Where(c => c.Sales.Count > 0)
                .ToArray()
                .Select(c => new CustomerDto()
                {
                    Name = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = Math.Round(c.Sales.Sum(s => s.Car.PartsCars.Sum(p => c.IsYoungDriver ? p.Part.Price * (100 - s.Discount) / 100 : p.Part.Price)), 2)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CustomerDto[]), new XmlRootAttribute("customers"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var customerXml = new StringWriter())
            {
                serializer.Serialize(customerXml, customers, ns);
                return customerXml.ToString();
            }
        }
    }
}