using System.ComponentModel.DataAnnotations;

namespace _01.MusicHubDatabase.Data.Models
{
    public class Producer
    {
        public Producer()
        {
            Albums = new List<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }

        public string? PhoneNumber { get; set; }

        public ICollection<Album> Albums { get; set; }
    }
}
