using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos
{
    public class PatientDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        public int AgeGroup { get; set; }

        [Required]
        public int Gender { get; set; }

        public int[] Medicines { get; set; }
    }
}
