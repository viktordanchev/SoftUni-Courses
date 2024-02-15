using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class ApplicationUser
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.ApplicationUser.UserNameMinLength)]
        [MaxLength(DataConstants.ApplicationUser.UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.ApplicationUser.EmailMinLength)]
        [MaxLength(DataConstants.ApplicationUser.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.ApplicationUser.PasswordMinLength)]
        [MaxLength(DataConstants.ApplicationUser.PasswordMaxLength)]
        public string Password { get; set; } = null!;
    }
}