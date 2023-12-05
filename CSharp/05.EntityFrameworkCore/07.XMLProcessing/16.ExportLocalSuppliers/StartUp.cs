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

            var output = GetLocalSuppliers(context);

            Console.WriteLine(output);
        }

        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var cars = context.Suppliers
                .Where(s => !s.IsImporter)
                .Select(c => new SupplierDto()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PartsCount = c.Parts.Count
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(SupplierDto[]), new XmlRootAttribute("suppliers"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var supplierDtoXml = new StringWriter())
            {
                serializer.Serialize(supplierDtoXml, cars, ns);
                return supplierDtoXml.ToString();
            }
        }
    }
}