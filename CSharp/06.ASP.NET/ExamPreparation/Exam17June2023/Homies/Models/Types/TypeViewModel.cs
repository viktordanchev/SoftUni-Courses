using Homies.Data;
using System.ComponentModel.DataAnnotations;

namespace Homies.Models.Types
{
    public class TypeViewModel
    {
        public int Id { get; set; }

        [MinLength(DataConstants.Type.NameMinLength)]
        [MaxLength(DataConstants.Type.NameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
