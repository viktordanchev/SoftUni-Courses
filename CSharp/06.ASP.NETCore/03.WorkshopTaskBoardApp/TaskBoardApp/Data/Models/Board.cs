using System.ComponentModel.DataAnnotations;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Board.BoardMinLength)]
        [MaxLength(DataConstants.Board.BoardMaxLength)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<Task> Tasks { get; set; } = new List<Task>();
    }
}
