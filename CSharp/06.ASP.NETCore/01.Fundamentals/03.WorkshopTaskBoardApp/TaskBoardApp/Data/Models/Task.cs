using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Task.TitleMinLength)]
        [MaxLength(DataConstants.Task.TitleMaxLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(DataConstants.Task.DescriptionMinLength)]
        [MaxLength(DataConstants.Task.DescriptionMaxLength)]
        public string Description { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public int BoardId { get; set; }

        [ForeignKey(nameof(BoardId))]
        public Board? Board { get; set; }

        [Required]
        public string OwnerId { get; set; } = string.Empty;

        [ForeignKey(nameof(OwnerId))]
        public IdentityUser Owner { get; set; } = null!;
    }
}
