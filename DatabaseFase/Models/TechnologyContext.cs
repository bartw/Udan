using Microsoft.Data.Entity;

namespace Udan.Models
{
    public class TechnologyContext : DbContext
    {
        public DbSet<Technology> Technologies { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlite("Data Source=./udan.db");
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Technology>().HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }
    }
}