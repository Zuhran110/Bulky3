﻿using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure relationships
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            
            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Fiction", DisplayOrder = 1, CreatedDate = DateTime.Now, IsActive = true },
                new Category { Id = 2, Name = "Non-Fiction", DisplayOrder = 2, CreatedDate = DateTime.Now, IsActive = true },
                new Category { Id = 3, Name = "Science Fiction", DisplayOrder = 3, CreatedDate = DateTime.Now, IsActive = true },
                new Category { Id = 4, Name = "Mystery", DisplayOrder = 4, CreatedDate = DateTime.Now, IsActive = true },
                new Category { Id = 5, Name = "Romance", DisplayOrder = 5, CreatedDate = DateTime.Now, IsActive = true }
            );
            
            // Seed Products with Category relationships
            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = 1,
                   Title = "Fortune of Time",
                   Author = "Billy Spark",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "SWD9999001",
                   ListPrice = 99,
                   Price = 90,
                   Price50 = 85,
                   Price100 = 80,
                   CategoryId = 1,
                   CreatedDate = DateTime.Now,
                   IsActive = true
               },
               new Product
               {
                   Id = 2,
                   Title = "Dark Skies",
                   Author = "Nancy Hoover",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "CAW777777701",
                   ListPrice = 40,
                   Price = 30,
                   Price50 = 25,
                   Price100 = 20,
                   CategoryId = 2,
                   CreatedDate = DateTime.Now,
                   IsActive = true
               },
               new Product
               {
                   Id = 3,
                   Title = "Vanish in the Sunset",
                   Author = "Julian Button",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "RITO5555501",
                   ListPrice = 55,
                   Price = 50,
                   Price50 = 40,
                   Price100 = 35,
                   CategoryId = 3,
                   CreatedDate = DateTime.Now,
                   IsActive = true
               },
               new Product
               {
                   Id = 4,
                   Title = "Cotton Candy",
                   Author = "Abby Muscles",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "WS3333333301",
                   ListPrice = 70,
                   Price = 65,
                   Price50 = 60,
                   Price100 = 55,
                   CategoryId = 4,
                   CreatedDate = DateTime.Now,
                   IsActive = true
               },
               new Product
               {
                   Id = 5,
                   Title = "Rock in the Ocean",
                   Author = "Ron Parker",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "SOTJ1111111101",
                   ListPrice = 30,
                   Price = 27,
                   Price50 = 25,
                   Price100 = 20,
                   CategoryId = 5,
                   CreatedDate = DateTime.Now,
                   IsActive = true
               },
               new Product
               {
                   Id = 6,
                   Title = "Leaves and Wonders",
                   Author = "Laura Phantom",
                   Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                   ISBN = "FOT000000001",
                   ListPrice = 25,
                   Price = 23,
                   Price50 = 22,
                   Price100 = 20,
                   CategoryId = 1,
                   CreatedDate = DateTime.Now,
                   IsActive = true
               }
            );
        }
    }
}