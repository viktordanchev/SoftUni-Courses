using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicines.Data.Models
{
    public class Medicine
    {
        public Medicine()
        {
            PatientsMedicines = new List<PatientMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(150)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(typeof(Decimal), "0.01", "1000")]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public DateTime ProductionDate { get; set; }

        [Required]
        public DateTime ExpiryDate { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Producer { get; set; } = null!;

        [Required]
        public int PharmacyId { get; set; }

        [ForeignKey(nameof(PharmacyId))]
        public Pharmacy Pharmacy { get; set; } = null!;

        public ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}
