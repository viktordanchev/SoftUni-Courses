using System.ComponentModel.DataAnnotations;

namespace ForumApp.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.TitleMinLength)]
        [MaxLength(DataConstants.TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.ContentMinLength)]
        [MaxLength(DataConstants.ContentMaxLength)]
        public string Content { get; set; } = null!;
    }
}
