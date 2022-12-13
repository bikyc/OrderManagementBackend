﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderManagement.DataAccess;

namespace OrderManagement.Migrations
{
    [DbContext(typeof(DataAccess.ApplicationDBContext))]
    [Migration("20221125113647_product_tbl_added")]
    partial class product_tbl_added
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderManagement.Entities.Customer", b =>
                {
                    b.Property<int>("cust_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("cust_id");

                    b.ToTable("tbl_Customer");
                });

            modelBuilder.Entity("OrderManagement.Entities.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("customercust_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("orderName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("order_id");

                    b.HasIndex("customercust_id");

                    b.ToTable("tbl_Order");
                });

            modelBuilder.Entity("OrderManagement.Entities.Product", b =>
                {
                    b.Property<int>("Prod_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("PMfdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("order_id")
                        .HasColumnType("int");

                    b.HasKey("Prod_id");

                    b.HasIndex("order_id");

                    b.ToTable("tbl_Product");
                });

            modelBuilder.Entity("OrderManagement.Entities.Order", b =>
                {
                    b.HasOne("OrderManagement.Entities.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customercust_id");
                });

            modelBuilder.Entity("OrderManagement.Entities.Product", b =>
                {
                    b.HasOne("OrderManagement.Entities.Order", "order")
                        .WithMany()
                        .HasForeignKey("order_id");
                });
#pragma warning restore 612, 618
        }
    }
}
