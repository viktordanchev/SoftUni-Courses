using CarDealer.Data;
using CarDealer.Models;
using ImportSuppliers.DTOs.Import;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            using var context = new CarDealerContext();

            var suppliersXml = File.ReadAllText(@"../../../Datasets/suppliers.xml");
            var output = ImportSuppliers(context, suppliersXml);

            Console.WriteLine(output);
        }

        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierDto[]), new XmlRootAttribute("Suppliers"));
            var supplierDtos = (SupplierDto[])serializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();
            foreach ( var supplierDto in supplierDtos)
            {
                var supplier = new Supplier()
                {
                    Name = supplierDto.Name,
                    IsImporter = supplierDto.IsImporter
                };

                suppliers.Add(supplier);
            }

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count}";
        }
    }
}