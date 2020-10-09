using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Entities;
using SalesManager.Persistence.Config;

namespace SalesManager.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base (options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new ClientConfig(builder.Entity<Client>());
            new OrderConfig(builder.Entity<Order>());
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new ProductConfig(builder.Entity<Product>());
        }
    }
}
