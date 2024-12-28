﻿// <auto-generated />
using System;
using BeSpoked.Bikes.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeSpoked.Bikes.API.Migrations
{
    [DbContext(typeof(BikesDbContext))]
    [Migration("20241228000707_Bike_Migration")]
    partial class Bike_Migration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BeSpoked.Bikes.API.Models.Customer", b =>
                {
                    b.Property<Guid>("CUST_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CUST_ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("BeSpoked.Bikes.API.Models.Products", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Commission_Percentage")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Purchase_Price")
                        .HasColumnType("float");

                    b.Property<int>("Qty_On_Hand")
                        .HasColumnType("int");

                    b.Property<double>("Sale_Price")
                        .HasColumnType("float");

                    b.Property<string>("Style")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BeSpoked.Bikes.API.Models.Sales", b =>
                {
                    b.Property<Guid>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CUST_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CustomerCUST_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductsProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SP_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalesPersonSP_ID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("sellDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SaleID");

                    b.HasIndex("CustomerCUST_ID");

                    b.HasIndex("ProductsProductID");

                    b.HasIndex("SalesPersonSP_ID");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("BeSpoked.Bikes.API.Models.SalesPerson", b =>
                {
                    b.Property<Guid>("SP_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("terminationdate")
                        .HasColumnType("datetime2");

                    b.HasKey("SP_ID");

                    b.ToTable("SalesPerson");
                });

            modelBuilder.Entity("BeSpoked.Bikes.API.Models.Sales", b =>
                {
                    b.HasOne("BeSpoked.Bikes.API.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerCUST_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSpoked.Bikes.API.Models.Products", "Products")
                        .WithMany()
                        .HasForeignKey("ProductsProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeSpoked.Bikes.API.Models.SalesPerson", "SalesPerson")
                        .WithMany()
                        .HasForeignKey("SalesPersonSP_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Products");

                    b.Navigation("SalesPerson");
                });
#pragma warning restore 612, 618
        }
    }
}
