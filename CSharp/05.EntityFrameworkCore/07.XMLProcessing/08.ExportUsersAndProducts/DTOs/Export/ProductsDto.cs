using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    public class ProductsDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public ProductDto[] Products { get; set; } = null!;
    }
}
