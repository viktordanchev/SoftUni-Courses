using Footballers.DataProcessor.ImportDto;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType("Coach")]
    public class CoachDto
    {
        [XmlAttribute("FootballersCount")]
        public int FootballersCount { get; set; }

        [XmlElement("CoachName")]
        public string CoachName { get; set; } = null!;

        [XmlArray("Footballers")]
        public FootballerDto[] Footballers { get; set; } = null!;
    }
}
