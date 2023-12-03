namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models.Enums;
    using Medicines.DataProcessor.ExportDtos;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            var parsedDate = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > parsedDate))
                .Select(p => new PatientDto()
                {
                    FullName = p.FullName,
                    AgeGroup = p.AgeGroup.ToString(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                        .Where(pm => pm.Medicine.ProductionDate > parsedDate)
                        .OrderByDescending(pm => pm.Medicine.ExpiryDate)
                        .ThenBy(pm => pm.Medicine.Price)
                        .Select(pm => new MedicineDto()
                        {
                            Category = pm.Medicine.Category.ToString().ToLower(),
                            Name = pm.Medicine.Name,
                            Price = pm.Medicine.Price.ToString("F2"),
                            Producer = pm.Medicine.Producer,
                            BestBefore = pm.Medicine.ExpiryDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture)
                        })
                        .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Length)
                .ThenBy(p => p.FullName)
                .ToArray();

            var serializer = new XmlSerializer(typeof(PatientDto[]), new XmlRootAttribute("Patients"));
            var ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            using (var patientsXml = new StringWriter())
            {
                serializer.Serialize(patientsXml, patients, ns);
                return patientsXml.ToString();
            }
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => m.Category == (Category)medicineCategory && m.Pharmacy.IsNonStop)
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("F2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .ToArray();

            var medicinesJson = JsonConvert.SerializeObject(medicines, Newtonsoft.Json.Formatting.Indented);

            return medicinesJson;
        }
    }
}
