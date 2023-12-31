﻿using HomeImpr.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeImpr.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Handyman> Handymans { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id=1, Name= "Electrician", DisplayOrder=1},
                new Category { Id=2, Name="Ceramist", DisplayOrder=2},
                new Category { Id=3, Name= "Carpenter", DisplayOrder=3}
                );

            modelBuilder.Entity<Handyman>().HasData(
                new Handyman
                {
                    Id=1,
                    Title= "Electrician",
                    Description= "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
                    Name="Mujo Mujić",
					Email = "mujo.mujic@gmail.com",
                    Price=60,
					CategoryId=1,
					ImageUrl="",
					CompanyEmail=""
				},
				new Handyman
				{
					Id = 2,
					Title = "Carpenter",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Haso Hasić",
					Email = "haso.hasic@gmail.com",
					Price = 150,
					CategoryId=3,
					ImageUrl = "",
					CompanyEmail=""
				},
				new Handyman
				{
					Id = 3,
					Title = "Electrician",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Djuro Djurić",
					Email = "djuro.djuric@gmail.com",
					Price = 80,
					CategoryId=1,
					ImageUrl = "",
					CompanyEmail=""
				},
				new Handyman
				{
					Id = 4,
					Title = "Ceramist",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Pera Perić",
					Email = "pera.peric@gmail.com",
					Price = 400,
					CategoryId=2,
					ImageUrl = "",
					CompanyEmail=""
				},
				new Handyman
				{
					Id = 5,
					Title = "Ceramist",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Nera Nerić",
					Email = "nera.neric@gmail.com",
					Price = 450,
					CategoryId=2,
					ImageUrl = "",
					CompanyEmail=""
				},
				new Handyman
				{
					Id = 6,
					Title = "Carpenter",
					Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.",
					Name = "Ramo Ramić",
					Email = "ramo.ramic@gmail.com",
					Price = 150,
					CategoryId=3,
					ImageUrl = "",
					CompanyEmail=""
				}
			);
        }
    }
}
