namespace Trucks.DataProcessor
{
    using Data;
    using Newtonsoft.Json;
    using System.Xml.Serialization;
    using Trucks.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportDespatchersWithTheirTrucks(TrucksContext context)
        {
            var despatchers = context.Despatchers
                .Where(d => d.Trucks.Count > 0)
                .AsEnumerable()
                .Select(d => new DespatcherDto()
                {
                    TrucksCount = d.Trucks.Count,
                    DespatcherName = d.Name,
                    Trucks = d.Trucks
                        .Select(d => new TruckDto 
                        {
                            RegistrationNumber = d.RegistrationNumber,
                            Make = d.MakeType
                        })
                        .OrderBy(d => d.RegistrationNumber)
                        .ToArray()
                })
                .OrderByDescending(d => d.Trucks.Length)
                .ThenBy(d => d.DespatcherName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(DespatcherDto[]), new XmlRootAttribute("Despatchers"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var despatchersXml = new StringWriter())
            {
                serializer.Serialize(despatchersXml, despatchers, ns);
                return despatchersXml.ToString();
            }
        }

        public static string ExportClientsWithMostTrucks(TrucksContext context, int capacity)
        {
            var clients = context.Clients
                .Where(c => c.ClientsTrucks.Any(t => t.Truck.TankCapacity >= capacity))
                .AsEnumerable()
                .Select(c => new
                {
                    Name = c.Name,
                    Trucks = c.ClientsTrucks
                        .Where(t => t.Truck.TankCapacity >= capacity)
                        .Select(t => new
                        {
                            TruckRegistrationNumber = t.Truck.RegistrationNumber,
                            VinNumber = t.Truck.VinNumber,
                            TankCapacity = t.Truck.TankCapacity,
                            CargoCapacity = t.Truck.CargoCapacity,
                            CategoryType = t.Truck.CategoryType.ToString(),
                            MakeType = t.Truck.MakeType.ToString()
                        })
                        .OrderBy(t => t.MakeType)
                        .ThenByDescending(t => t.CargoCapacity)
                        .ToArray()
                })
                .OrderByDescending(c => c.Trucks.Length)
                .ThenBy(c => c.Name)
                .Take(10)
                .ToArray();

            var clientJson = JsonConvert.SerializeObject(clients, Formatting.Indented);

            return clientJson;
        }
    }
}
