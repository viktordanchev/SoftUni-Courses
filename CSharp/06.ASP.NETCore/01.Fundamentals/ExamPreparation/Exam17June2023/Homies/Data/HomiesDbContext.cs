using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Homies.Data
{
    public class HomiesDbContext : IdentityDbContext
    {
        public HomiesDbContext(DbContextOptions<HomiesDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder
            //    .Entity<Type>()
            //    .HasData(new Type()
            //    {
            //        Id = 1,
            //        Name = "Animals"
            //    },
            //    new Type()
            //    {
            //        Id = 2,
            //        Name = "Fun"
            //    },
            //    new Type()
            //    {
            //        Id = 3,
            //        Name = "Discussion"
            //    },
            //    new Type()
            //    {
            //        Id = 4,
            //        Name = "Work"
            //    });

            //base.OnModelCreating(modelBuilder);
        }
    }
}