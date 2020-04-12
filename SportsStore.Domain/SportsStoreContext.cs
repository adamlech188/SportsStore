using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SportsStore.Domain.Entities;
using System;
using Microsoft.Extensions.Configuration;

namespace SportsStore.Domain
{
    public class SportsStoreContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Category { get; set; }
        public SportsStoreContext()
        {
            Configuration = DataBaseConfigurationBuilder.GetConfiguration();
        }
        public SportsStoreContext(DbContextOptions<SportsStoreContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("SportsStoreConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>().HasData(
                 new Category
                 {
                     CategoryId = 1,
                     Name = "Watersports"
                 },
                 new Category
                 {
                     CategoryId = 2,
                     Name = "Soccer"
                 },
                       new Category
                       {
                           CategoryId = 3,
                           Name = "Chess"
                       }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Kayak", Description = "A boat for one person", Price = 275.00M, CategoryId = 1 },
                new Product { ProductID = 2, Name = "Lifejacket", Description = "Protective and fashionable", Price = 48.95M, CategoryId = 1 },
                new Product { ProductID = 3, Name = "Soccer Ball", Description = "FIFA-approved size and weight", Price = 19.50M, CategoryId = 2 },
                new Product { ProductID = 4, Name = "Corner Flags", Description = "Give your playing field a professional touch", Price = 34.95M, CategoryId = 2 },
                new Product { ProductID = 5, Name = "Stadium", Description = "Flat-packed 35000-seat stadium", Price = 79500M, CategoryId = 2 },
                new Product { ProductID = 6, Name = "Thinking Cap", Description = "Improve your brain efficiency by 75%", Price = 16.00M, CategoryId = 3 },
                new Product { ProductID = 7, Name = "Unsteady Chair", Description = "Secretly give your opponent a disadvantage", Price = 29.950M, CategoryId = 3 },
                new Product { ProductID = 8, Name = "Human Chess Board", Description = "A fun game for the family", Price = 75.00M, CategoryId = 3 },
                new Product { ProductID = 9, Name = "Bling-Bling King", Description = "Gold-plated, diamond-studded King", Price = 1200.00M, CategoryId = 1 }
            );
        }

    }
}
