using BeSpoked.Bikes.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BeSpoked.Bikes.API.Data
{
    public class BikesDbContext : DbContext
    {
        public BikesDbContext(DbContextOptions dbContextOptions)  : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                        .HasKey(c => c.CUST_ID);  // Explicitly define the primary key

            modelBuilder.Entity<Products>()
                        .HasKey(c => c.ProductID);  // Explicitly define the primary key
            modelBuilder.Entity<SalesPerson>()
                        .HasKey(c => c.SP_ID);  // Explicitly define the primary key

            modelBuilder.Entity<Sales>()
                       .HasKey(c => c.SaleID);  // Explicitly define the primary key

        }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Products> Products { get; set; }

        public DbSet<SalesPerson> SalesPerson { get; set; }

        public DbSet<Sales> Sales { get; set; }

    }
}
