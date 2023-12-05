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

            var output = GetCarsWithDistance(context);

            Console.WriteLine(output);
        }

        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.TraveledDistance > 2_000_000)
                .Select(c => new CarDto()
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("cars"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var carXml = new StringWriter())
            {
                serializer.Serialize(carXml, cars, ns);
                return carXml.ToString();
            }
        }
    }
}