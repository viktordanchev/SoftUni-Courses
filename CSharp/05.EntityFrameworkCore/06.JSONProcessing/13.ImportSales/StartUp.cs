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

            var salesJson = File.ReadAllText(@"../../../Datasets/sales.json");
            var output = ImportSales(context, salesJson);

            Console.WriteLine(output);
        }

        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            var saleDTOs = JsonConvert.DeserializeObject<SaleDTO[]>(inputJson);
            var sales = mapper.Map<Sale[]>(saleDTOs);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}