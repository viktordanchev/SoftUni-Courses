using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ExportDtos
{
    [XmlType("Medicine")]
    public class MedicineDto
    {
        [XmlAttribute("Category")]
        [Required]
        public string Category { get; set; } = null!;

        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [XmlElement("Price")]
        [Required]
        public string Price { get; set; } = null!;

        [XmlElement("Producer")]
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; } = null!;

        [XmlElement("BestBefore")]
        [Required]
        public string BestBefore { get; set; } = null!;
    }
}
