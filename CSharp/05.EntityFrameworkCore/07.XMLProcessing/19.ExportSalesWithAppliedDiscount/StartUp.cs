using CarDealer.Data;
using CarDealer.DTOs.Export;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var output = GetSalesWithAppliedDiscount(context);

            Console.WriteLine(output);
        }

        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Select(s => new SaleDto()
                {
                    Car = new CarDto()
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars.Sum(pc => pc.Part.Price),
                    PriceWithDiscount = s.Car.PartsCars.Sum(pc => pc.Part.Price) * (100 - s.Discount) / 100
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(SaleDto[]), new XmlRootAttribute("sales"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var salesXml = new StringWriter())
            {
                serializer.Serialize(salesXml, sales, ns);
                return salesXml.ToString();
            }
        }
    }
}