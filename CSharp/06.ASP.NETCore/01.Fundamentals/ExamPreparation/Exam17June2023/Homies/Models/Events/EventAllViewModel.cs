using Homies.Data;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models.Events
{
    public class EventAllViewModel
    {
        public int Id { get; set; }

        [MinLength(DataConstants.Event.NameMinLength)]
        [MaxLength(DataConstants.Event.NameMaxLength)]
        public string Name { get; set; }

        public string Start { get; set; }

        public string Type { get; set; }

        public string Organiser { get; set; }
    }
}
