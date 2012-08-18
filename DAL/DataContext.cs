using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Seller.Models;

namespace Seller.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Offer> Offers { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}