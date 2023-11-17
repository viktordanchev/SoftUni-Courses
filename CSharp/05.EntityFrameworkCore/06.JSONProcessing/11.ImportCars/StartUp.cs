using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var carJson = File.ReadAllText(@"../../../Datasets/cars.json");
            var output = ImportCars(context, carJson);

            Console.WriteLine(output);
        }

        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            var carDTOs = JsonConvert.DeserializeObject<CarDTO[]>(inputJson);
            var cars = mapper.Map<Car[]>(carDTOs);

            foreach (var carDTO in carDTOs)
            {
                var car = mapper.Map<Car>(carDTO);

                foreach (var partId in carDTO.PartsId.Distinct())
                {
                    context.PartsCars.Add(new PartCar
                    {
                        PartId = partId,
                        Car = car
                    });
                }
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }
    }
}