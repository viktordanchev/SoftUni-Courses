using System.ComponentModel.DataAnnotations;

namespace Homies.Data.Models
{
    public class Type
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Type.NameMinLength)]
        [MaxLength(DataConstants.Type.NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Event> Events { get; set; } = new List<Event>();
    }
}
