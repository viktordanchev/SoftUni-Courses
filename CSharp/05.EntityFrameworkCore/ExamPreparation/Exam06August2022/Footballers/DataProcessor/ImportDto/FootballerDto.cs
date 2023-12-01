using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ImportDto
{
    [XmlType("Footballer")]
    public class FootballerDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; } = null!;

        [XmlElement("ContractStartDate")]
        [Required]
        public string ContractStartDate { get; set; } = null!;

        [XmlElement("ContractEndDate")]
        [Required]
        public string ContractEndDate { get; set; } = null!;

        [XmlElement("BestSkillType")]
        [Required]
        public int BestSkillType { get; set; }

        [XmlElement("PositionType")]
        [Required]
        public int PositionType { get; set; }
    }
}
