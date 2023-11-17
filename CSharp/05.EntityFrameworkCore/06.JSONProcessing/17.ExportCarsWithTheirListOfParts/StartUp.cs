using CarDealer.Data;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var output = GetCarsWithTheirListOfParts(context);

            Console.WriteLine(output);
        }

        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance,
                    Parts = c.PartsCars
                    .Select(p => new
                    {
                        p.Part.Name,
                        Price = p.Part.Price.ToString("F2")
                    })
                    .ToList()
                })
                .ToArray();

            var carsJson = JsonConvert.SerializeObject(cars.Select(c => new
            {
                car = new
                {
                    c.Make,
                    c.Model,
                    c.TraveledDistance
                },
                parts = c.Parts
            }), Formatting.Indented);

            return carsJson;
        }
    }
}