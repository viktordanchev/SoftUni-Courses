using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Trucks.Data.Models.Enums;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Truck")]
    public class TruckDto
    {
        [XmlElement("RegistrationNumber")]
        [RegularExpression(@"[A-Z]{2}[0-9]{4}[A-Z]{2}")]
        [StringLength(8)]
        public string? RegistrationNumber { get; set; }

        [XmlElement("Make")]
        [Required]
        public MakeType Make { get; set; }
    }
}
