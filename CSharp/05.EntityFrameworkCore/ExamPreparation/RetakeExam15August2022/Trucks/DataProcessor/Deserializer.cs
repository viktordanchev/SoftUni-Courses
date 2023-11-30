namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using Trucks.Data.Models;
    using Trucks.Data.Models.Enums;
    using Trucks.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(DespatcherDto[]), new XmlRootAttribute("Despatchers"));
            var despatcherDtos = (DespatcherDto[])serializer.Deserialize(new StringReader(xmlString));
            var validDespatchers = new List<Despatcher>();

            var result = new StringBuilder();
            foreach (var despatcherDto in despatcherDtos)
            {
                if (!IsValid(despatcherDto) || string.IsNullOrEmpty(despatcherDto.Position))
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var validDespatcher = new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position
                };

                foreach (var truck in despatcherDto.Trucks)
                {
                    if (!IsValid(truck) || string.IsNullOrEmpty(truck.RegistrationNumber))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validTruck = new Truck()
                    {
                        RegistrationNumber = truck.RegistrationNumber,
                        VinNumber = truck.VinNumber,
                        TankCapacity = truck.TankCapacity,
                        CargoCapacity = truck.CargoCapacity,
                        CategoryType = (CategoryType)truck.CategoryType,
                        MakeType = (MakeType)truck.MakeType
                    };

                    validDespatcher.Trucks.Add(validTruck);
                }

                validDespatchers.Add(validDespatcher);
                result.AppendLine(string.Format(SuccessfullyImportedDespatcher, validDespatcher.Name, validDespatcher.Trucks.Count));
            }

            context.Despatchers.AddRange(validDespatchers);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        public static string ImportClient(TrucksContext context, string jsonString)
        {
            var clientDtos = JsonConvert.DeserializeObject<ClientDto[]>(jsonString);
            var existingTrucks = context.Trucks.Select(t => t.Id).ToList();
            var validClients = new List<Client>();

            var result = new StringBuilder();
            foreach (var clientDto in clientDtos)
            {
                if (!IsValid(clientDto) || clientDto.Type == "usual")
                {
                    result.AppendLine(ErrorMessage);
                    continue;
                }

                var validClient = new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type
                };

                foreach (var truckId in clientDto.Trucks)
                {
                    if (!existingTrucks.Contains(truckId))
                    {
                        result.AppendLine(ErrorMessage);
                        continue;
                    }

                    var validClientTruck = new ClientTruck()
                    {
                        Client = validClient,
                        TruckId = truckId
                    };

                    validClient.ClientsTrucks.Add(validClientTruck);
                }

                validClients.Add(validClient);
                result.AppendLine(string.Format(SuccessfullyImportedClient, validClient.Name, validClient.ClientsTrucks.Count));
            }

            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return result.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}