using Homies.Data;
using Homies.Models.Types;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models.Events
{
    public class EventViewModel
    {
        public int Id { get; set; }

        [MinLength(DataConstants.Event.NameMinLength)]
        [MaxLength(DataConstants.Event.NameMaxLength)]
        public string Name { get; set; }

        [MinLength(DataConstants.Event.DescriptionMinLength)]
        [MaxLength(DataConstants.Event.DescriptionMaxLength)]
        public string Description { get; set; }

        public string Organiser { get; set; }

        public string CreatedOn { get; set; }

        public string Start { get; set; }

        public string End { get; set; }

        public int TypeId { get; set; }

        public string Type { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
    }
}
