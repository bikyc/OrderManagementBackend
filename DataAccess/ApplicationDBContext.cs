using Microsoft.EntityFrameworkCore;
using OrderManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.DataAccess
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
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
                        .ToTable("tbl_User");

            //base.OnModelCreating(builder);
            //builder.Entity<Roles>()
            //            .ToTable("tbl_Role");

            //builder.Entity<Users>()
            //.HasMany(u => u.Roles)
            //.WithMany(u => u.Users)
            //.UsingEntity(u => u.ToTable("tbl_Users"));
        }

        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }

        public DbSet<Product> products { get; set; }


    }
}
