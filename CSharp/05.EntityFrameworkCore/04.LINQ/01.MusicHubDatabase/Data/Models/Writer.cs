using System.ComponentModel.DataAnnotations;

namespace _01.MusicHubDatabase.Data.Models
{
    public class Writer
    {
        public Writer()
        {
            Songs = new List<Song>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; } = null!;

        public string? Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
