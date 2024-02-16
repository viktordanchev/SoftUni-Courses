using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homies.Data.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(DataConstants.Event.NameMinLength)]
        [MaxLength(DataConstants.Event.NameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MinLength(DataConstants.Event.DescriptionMinLength)]
        [MaxLength(DataConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganiserId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(OrganiserId))]
        public IdentityUser Organiser { get; set; } = null!;

        [Required]
        public DateTime CreatedOn { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        public IEnumerable<EventParticipant> EventsParticipants { get; set; } = new List<EventParticipant>();
    }
}