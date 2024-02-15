using System.ComponentModel.DataAnnotations;

namespace Contacts.Data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Website { get; set; }
    }
}

//•	Has Id – a unique integer, Primary Key
//•	Has FirstName – a string with min length 2 and max length 50 (required)
//•	Has LastName – a string with min length 5 and max length 50 (required)
//•	Has Email – a string with min length 10 and max length 60 (required)
//•	Has PhoneNumber – a string with min length 10 and max length 13 (required). The phone number must start with "+359" or '0' (zero), followed by four sets of digits, separated by a space, '-' (dash) or nothing between the sets. The first group must have exactly three digits and the others exactly two digits. Valid examples: 0 875 23 45 15, +359 - 883 - 15 - 12 - 10, 0889552217.
//•	Has Address – a string 
//•	Has Website – a string. First four characters are "www.", followed by letters, digits or '-' and last three characters are ".bg" (required)
//•	Has ApplicationUsersContacts – a collection of type ApplicationUserContact