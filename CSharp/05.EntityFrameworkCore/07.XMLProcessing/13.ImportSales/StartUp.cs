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

            var salesXml = File.ReadAllText(@"../../../Datasets/sales.xml");
            var output = ImportSales(context, salesXml);

            Console.WriteLine(output);
        }

        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SaleDto[]), new XmlRootAttribute("Sales"));
            var saleDtos = (SaleDto[])serializer.Deserialize(new StringReader(inputXml));

            var validCarIds = context.Cars.Select(s => s.Id).ToList();
            var sales = new List<Sale>();

            foreach (var saleDto in saleDtos)
            {
                if (!validCarIds.Contains(saleDto.CarId))
                {
                    continue;
                }

                var sale = new Sale()
                {
                    CarId = saleDto.CarId,
                    CustomerId = saleDto.CustomerId,
                    Discount = saleDto.Discount
                };

                sales.Add(sale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }
    }
}