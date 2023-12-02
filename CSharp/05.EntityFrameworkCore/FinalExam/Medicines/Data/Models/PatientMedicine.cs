using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        [Required]
        public int PatientId { get; set; }

        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; } = null!;

        [Required]
        public int MedicineId { get; set; }

        [ForeignKey(nameof(MedicineId))]
        public Medicine Medicine { get; set; } = null!;
    }
}
