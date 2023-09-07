using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Farmer> Farmers { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Farmer>()
                .HasKey(farmer => farmer.FarmerRegistrationNumber);

            modelBuilder.Entity<Farmer>()
                .Property(farmer => farmer.Country)
                .HasConversion(
                    v => v.ToString(),
                    v => (CountryName)Enum.Parse(typeof(CountryName), v)
                );



            modelBuilder.Entity<Category>()
            .Property(e => e.Name)
            .HasConversion(
                v => v.ToString(),
                v => (CategoryName)Enum.Parse(typeof(CategoryName), v)
            );

            modelBuilder.Entity<Product>()
            .Property(e => e.Name)
            .HasConversion(
                v => v.ToString(),
                v => (ProductName)Enum.Parse(typeof(ProductName), v)
            );



        }
    }
}
