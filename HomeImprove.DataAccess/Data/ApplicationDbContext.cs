using HomeImpr.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeImpr.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Handyman> Handymans { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name="Električar", DisplayOrder=1},
                new Category { Id=2, Name="Keramičar", DisplayOrder=2},
                new Category { Id=3, Name="Stolar", DisplayOrder=3}
                );

            modelBuilder.Entity<Handyman>().HasData(
                new Handyman
                {
                    Id=1,
                    Title="Električar",
                    Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Name="Mujo Mujić",
                    Price=60,
					CategoryId=1,
					ImageUrl=""
				},
				new Handyman
				{
					Id = 2,
					Title = "Stolar",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Haso Hasić",
					Price = 150,
					CategoryId=3,
					ImageUrl = ""
				},
				new Handyman
				{
					Id = 3,
					Title = "Električar",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Djuro Djurić",
					Price = 80,
					CategoryId=1,
					ImageUrl = ""
				},
				new Handyman
				{
					Id = 4,
					Title = "Keramičar",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Pera Perić",
					Price = 400,
					CategoryId=2,
					ImageUrl = ""
				},
				new Handyman
				{
					Id = 5,
					Title = "Keramičar",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Nera Nerić",
					Price = 450,
					CategoryId=2,
					ImageUrl = ""
				},
				new Handyman
				{
					Id = 6,
					Title = "Stolar",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Ramo Ramić",
					Price = 150,
					CategoryId=3,
					ImageUrl = ""
				}
			);
        }
    }
}
