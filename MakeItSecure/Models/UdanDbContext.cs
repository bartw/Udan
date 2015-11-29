using Microsoft.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Udan.Models
{
    public class ApplicationUser : IdentityUser {}
    
    public class UdanDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Technology> Technologies { get; set; }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Technology>().HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
    }
}