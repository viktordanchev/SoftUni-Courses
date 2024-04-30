using Contacts.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ApplicationUserContact> ApplicationUsersContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserContact>()
                .HasKey(auc => new { auc.ApplicationUserId, auc.ContactId });

            base.OnModelCreating(builder);
        }
    }
}
