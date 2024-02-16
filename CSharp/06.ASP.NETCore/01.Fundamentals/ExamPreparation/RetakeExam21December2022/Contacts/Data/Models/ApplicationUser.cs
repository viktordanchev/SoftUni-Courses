using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.ApplicationUser.UserNameMinLength)]
        [MaxLength(DataConstants.ApplicationUser.UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.EmailMinLength)]
        [MaxLength(DataConstants.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.ApplicationUser.PasswordMinLength)]
        [MaxLength(DataConstants.ApplicationUser.PasswordMaxLength)]
        public string Password { get; set; } = null!;

        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}