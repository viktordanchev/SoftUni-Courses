using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models
{
    public class Patient
    {
        public Patient()
        {
            PatientsMedicines = new List<PatientMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public AgeGroup AgeGroup { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public ICollection<PatientMedicine> PatientsMedicines { get; set; }
    }
}
