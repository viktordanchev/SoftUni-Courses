using CarDealer.Data;
using CarDealer.Models;
using CarDealer.DTOs.Import;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var partsXml = File.ReadAllText(@"../../../Datasets/parts.xml");
            var output = ImportParts(context, partsXml);

            Console.WriteLine(output);
        }

        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartDto[]), new XmlRootAttribute("Parts"));
            var partsDtos = (PartDto[])serializer.Deserialize(new StringReader(inputXml));

            var validSupplierIds = context.Suppliers.Select(s => s.Id).ToList();
            var parts = new List<Part>();

            foreach ( var partsDto in partsDtos)
            {
                if(!validSupplierIds.Contains(partsDto.SupplierId))
                {
                    continue;
                }

                var part = new Part()
                {
                    Name = partsDto.Name,
                    Price = partsDto.Price,
                    Quantity = partsDto.Quantity,
                    SupplierId = partsDto.SupplierId
                };

                parts.Add(part);
            }

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count}";
        }
    }
}