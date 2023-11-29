using System.Xml.Serialization;

namespace _06.ExportSoldProducts.DTOs.Export
{
    [XmlType("User")]
    public class UserDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        public string LastName { get; set; } = null!;

        [XmlArray("soldProducts")]
        public ProductDto[] SoldProducts { get; set; } = null!;
    }
}
