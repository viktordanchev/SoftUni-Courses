using System.Xml.Serialization;

namespace ImportSuppliers.DTOs.Import
{
    [XmlType("Supplier")]
    public class SupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
