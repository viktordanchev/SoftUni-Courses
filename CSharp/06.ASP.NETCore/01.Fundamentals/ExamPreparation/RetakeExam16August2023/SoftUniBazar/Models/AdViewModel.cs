using Microsoft.AspNetCore.Identity;
using SoftUniBazar.Data.Models;

namespace SoftUniBazar.Models
{
    public class AdViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string OwnerId { get; set; }
        public IdentityUser Owner { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
