using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTOs.Import;
using System.Xml.Serialization;
using System.Linq;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var carsXml = File.ReadAllText(@"../../../Datasets/cars.xml");
            var output = ImportCars(context, carsXml);

            Console.WriteLine(output);
        }

        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarDto[]), new XmlRootAttribute("Cars"));
            var carDtos = (CarDto[])serializer.Deserialize(new StringReader(inputXml));

            var validPartIds = context.Parts.Select(s => s.Id).ToList();
            var cars = new List<Car>();

            foreach (var carDto in carDtos)
            {
                var car = new Car()
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TraveledDistance = carDto.TraveledDistance
                };

                foreach (var partId in carDto.PartIds)
                {
                    var partCar = new PartCar()
                    {
                        PartId = partId.Id,
                        Car = car
                    };

                    if (!validPartIds.Contains(partId.Id)
                        || car.PartsCars.Any(pc => pc.PartId == partCar.PartId))
                    {
                        continue;
                    }

                    car.PartsCars.Add(partCar);
                }

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }
    }
}