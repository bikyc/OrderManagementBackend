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
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221213173423_addUserRoles_V1")]
    partial class addUserRoles_V1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("OrderManagement.Entities.Customer", b =>
                {
                    b.Property<int>("cust_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

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
                        .UseIdentityColumn();

                    b.Property<int?>("customercust_id")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("orderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("productProd_id")
                        .HasColumnType("int");

                    b.Property<decimal>("quantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("totalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("order_id");

                    b.HasIndex("customercust_id");

                    b.HasIndex("productProd_id");

                    b.ToTable("tbl_Order");
                });

            modelBuilder.Entity("OrderManagement.Entities.Product", b =>
                {
                    b.Property<int>("Prod_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("PMfdDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PPrice")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.HasKey("Prod_id");

                    b.ToTable("tbl_Product");
                });

            modelBuilder.Entity("OrderManagement.Entities.Order", b =>
                {
                    b.HasOne("OrderManagement.Entities.Customer", "customer")
                        .WithMany()
                        .HasForeignKey("customercust_id");

                    b.HasOne("OrderManagement.Entities.Product", "product")
                        .WithMany()
                        .HasForeignKey("productProd_id");

                    b.Navigation("customer");

                    b.Navigation("product");
                });
#pragma warning restore 612, 618
        }
    }
}
