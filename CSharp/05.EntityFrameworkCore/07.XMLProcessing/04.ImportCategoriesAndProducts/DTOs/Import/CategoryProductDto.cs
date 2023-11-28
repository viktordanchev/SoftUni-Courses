using System.Xml.Serialization;

namespace _04.ImportCategoriesAndProducts.DTOs.Import
{
    [XmlType("CategoryProduct")]
    public class CategoryProductDto
    {
        [XmlElement("CategoryId")]
        public int CategoryId { get; set; }

        [XmlElement("ProductId")]
        public int ProductId { get; set; }
    }
}
