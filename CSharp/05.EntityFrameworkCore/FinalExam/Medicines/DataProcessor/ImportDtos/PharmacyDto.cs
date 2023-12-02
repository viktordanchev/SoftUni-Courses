using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class PharmacyDto
    {
        [XmlAttribute("non-stop")]
        [Required]
        public string IsNonStop { get; set; } = null!;

        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [XmlElement("PhoneNumber")]
        [Required]
        [StringLength(14)]
        [RegularExpression(@"^\([0-9]{3}\)\s[0-9]{3}\-[0-9]{4}$")]
        public string PhoneNumber { get; set; } = null!;

        public MedicineDto[] Medicines { get; set; }
    }
}
