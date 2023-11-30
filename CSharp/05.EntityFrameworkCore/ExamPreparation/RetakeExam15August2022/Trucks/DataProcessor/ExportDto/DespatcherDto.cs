using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class DespatcherDto
    {
        [XmlAttribute("TrucksCount")]
        public int TrucksCount { get; set; }

        [XmlElement("DespatcherName")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string DespatcherName { get; set; } = null!;

        [XmlArray("Trucks")]
        public TruckDto[]? Trucks { get; set; }
    }
}
