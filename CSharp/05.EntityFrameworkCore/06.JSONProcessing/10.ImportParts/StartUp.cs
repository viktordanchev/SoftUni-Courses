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

            var suppliersJson = File.ReadAllText(@"../../../Datasets/parts.json");
            var output = ImportParts(context, suppliersJson);

            Console.WriteLine(output);
        }

        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<CarDealerProfile>());
            IMapper mapper = new Mapper(config);

            var supplierIds = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var partDTOs = JsonConvert.DeserializeObject<PartDTO[]>(inputJson);
            var parts = mapper.Map<Part[]>(partDTOs)
                .Where(p => supplierIds.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }
    }
}