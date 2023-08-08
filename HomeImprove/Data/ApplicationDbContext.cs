using HomeImprove.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeImprove.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Električar", DisplayOrder=1},
                new Category { Id=2, Name="Keramičar", DisplayOrder=2},
                new Category { Id=3, Name="Stolar", DisplayOrder=3}
                );
        }
    }
}
