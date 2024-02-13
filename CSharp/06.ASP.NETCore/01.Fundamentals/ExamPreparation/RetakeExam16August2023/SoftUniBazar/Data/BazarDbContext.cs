using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoftUniBazar.Data
{
    public class BazarDbContext : IdentityDbContext
    {
        public BazarDbContext(DbContextOptions<BazarDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            //modelBuilder
            //    .Entity<Category>()
            //    .HasData(new Category()
            //    {
            //        Id = 1,
            //        Name = "Books"
            //    },
            //    new Category()
            //    {
            //        Id = 2,
            //        Name = "Cars"
            //    },
            //    new Category()
            //    {
            //        Id = 3,
            //        Name = "Clothes"
            //    },
            //    new Category()
            //    {
            //        Id = 4,
            //        Name = "Home"
            //    },
            //    new Category()
            //    {
            //        Id = 5,
            //        Name = "Technology"
            //    });
            //
            // base.OnModelCreating(modelBuilder);
        }
    }
}