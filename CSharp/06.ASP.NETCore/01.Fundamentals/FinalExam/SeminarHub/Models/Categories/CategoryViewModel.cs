using SeminarHub.Data;
using System.ComponentModel.DataAnnotations;

namespace SeminarHub.Models.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Category.NameMinLength)]
        [MaxLength(DataConstants.Category.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
