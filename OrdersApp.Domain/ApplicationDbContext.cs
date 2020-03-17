using System.Data.Entity;
using OrdersApp.Models.Entities;

namespace OrdersApp.Domain
{
    public class ApplicationDbContext : DbContext
    {
        // for automatic migrations
        public ApplicationDbContext()
            : this("DefaultConnection")
        {

        }

        public ApplicationDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Migrations.Configuration>());
        }

        public DbSet<Models.Entities.TestOrder> TestOrders { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
        public DbSet<TestProduct> TestProducts { get; set; }
        public DbSet<TestOrderProduct> TestOrderProducts { get; set; }
        public DbSet<TestProductCategory> TestProductCategories { get; set; }
    }
}
