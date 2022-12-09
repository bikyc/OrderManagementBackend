

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Authentication;
using OrderManagement.Entities;

namespace OrderManagement.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>()
                       .ToTable("tbl_Customer");

            base.OnModelCreating(builder);
            builder.Entity<Order>()
                       .ToTable("tbl_Order");

            base.OnModelCreating(builder);
            builder.Entity<Product>()
                        .ToTable("tbl_Product");

            base.OnModelCreating(builder);
            builder.Entity<Users>()
                        .ToTable("tbl_users");
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }

        public DbSet<Product> products { get; set; }

        public DbSet<Users> users { get; set; }
    }
}
