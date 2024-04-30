using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Contact.FirstNameMinLength)]
        [MaxLength(DataConstants.Contact.FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Contact.LastNameMinLength)]
        [MaxLength(DataConstants.Contact.LastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.EmailMinLength)]
        [MaxLength(DataConstants.EmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Contact.PhoneNumberMinLength)]
        [MaxLength(DataConstants.Contact.PhoneNumberMaxLength)]
        [RegularExpression(DataConstants.Contact.PhoneNumberRegex)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        [RegularExpression(DataConstants.Contact.WebsiteRegex)]
        public string Website { get; set; } = null!;

        public IEnumerable<ApplicationUserContact> ApplicationUsersContacts { get; set; } = new List<ApplicationUserContact>();
    }
}