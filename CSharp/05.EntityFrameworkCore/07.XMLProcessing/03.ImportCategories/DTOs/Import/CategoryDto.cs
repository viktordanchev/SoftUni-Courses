using System.Xml.Serialization;

namespace _03.ImportCategories.DTOs.Import
{
    [XmlType("Category")]
    public class CategoryDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}
