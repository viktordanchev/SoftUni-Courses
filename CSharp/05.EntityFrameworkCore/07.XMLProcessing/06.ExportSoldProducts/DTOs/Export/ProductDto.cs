using System.Xml.Serialization;

namespace _06.ExportSoldProducts.DTOs.Export
{
    [XmlType("Product")]
    public class ProductDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }
    }
}
