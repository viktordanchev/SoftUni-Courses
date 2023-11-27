using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class CreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string? FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [Required]
        [MinLength(2)]
        [MaxLength(7)]
        public string? LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public BoardgameDto[] Boardgames { get; set; } = null!;
    }
}
