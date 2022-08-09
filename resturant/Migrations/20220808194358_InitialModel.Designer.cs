﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using resturant.Models;

namespace resturant.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220808194358_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("resturant.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("homeLocation")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("resturant.Models.FullReport", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("EachSupplierTotal")
                        .HasColumnType("double");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplyingInvoiceInvoiceId")
                        .HasColumnType("int");

                    b.Property<double>("TotalOfPurchase")
                        .HasColumnType("double");

                    b.Property<string>("goodsName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("storage")
                        .HasColumnType("int");

                    b.Property<string>("supplierName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("supplyingDate")
                        .HasColumnType("datetime");

                    b.HasKey("ReportId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("SupplyingInvoiceInvoiceId");

                    b.ToTable("FullReport");
                });

            modelBuilder.Entity("resturant.Models.Manager", b =>
                {
                    b.Property<int>("ManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("email")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("password")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("phoneNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("username")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("ManagerId");

                    b.HasIndex("AddressId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("resturant.Models.StockItems", b =>
                {
                    b.Property<int>("StockId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SupplyingId")
                        .HasColumnType("int");

                    b.Property<string>("goodsName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("stockNumber")
                        .HasColumnType("int");

                    b.Property<int>("storage")
                        .HasColumnType("int");

                    b.HasKey("StockId");

                    b.HasIndex("SupplyingId");

                    b.ToTable("StockItems");
                });

            modelBuilder.Entity("resturant.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("supplierLocation")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("supplierName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("supplierNumber")
                        .HasColumnType("int");

                    b.Property<string>("supplierPhone")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("SupplierId");

                    b.HasIndex("ManagerId");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("resturant.Models.Supplying", b =>
                {
                    b.Property<int>("SupplyingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("amount")
                        .HasColumnType("int");

                    b.Property<string>("goodsName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("supplyingDate")
                        .HasColumnType("datetime");

                    b.Property<int>("supplyingNumber")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("SupplyingId");

                    b.ToTable("Supplying");
                });

            modelBuilder.Entity("resturant.Models.SupplyingInvoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("APDTotalCost")
                        .HasColumnType("double");

                    b.Property<string>("InvoiceStatus")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SupplyingId")
                        .HasColumnType("int");

                    b.Property<double>("TotalOfPurchase")
                        .HasColumnType("double");

                    b.Property<double>("discount")
                        .HasColumnType("double");

                    b.Property<int>("goodsAmount")
                        .HasColumnType("int");

                    b.Property<string>("goodsName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("invoiceDate")
                        .HasColumnType("datetime");

                    b.Property<double>("price")
                        .HasColumnType("double");

                    b.Property<string>("supplierName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("InvoiceId");

                    b.HasIndex("SupplyingId");

                    b.ToTable("SupplyingInvoice");
                });

            modelBuilder.Entity("resturant.Models.SupplyingProcess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("SupplyingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.HasIndex("SupplyingId");

                    b.ToTable("SupplyingProcess");
                });

            modelBuilder.Entity("resturant.Models.FullReport", b =>
                {
                    b.HasOne("resturant.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("resturant.Models.SupplyingInvoice", "SupplyingInvoice")
                        .WithMany()
                        .HasForeignKey("SupplyingInvoiceInvoiceId");

                    b.Navigation("Manager");

                    b.Navigation("SupplyingInvoice");
                });

            modelBuilder.Entity("resturant.Models.Manager", b =>
                {
                    b.HasOne("resturant.Models.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("resturant.Models.StockItems", b =>
                {
                    b.HasOne("resturant.Models.Supplying", "Supplying")
                        .WithMany()
                        .HasForeignKey("SupplyingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplying");
                });

            modelBuilder.Entity("resturant.Models.Supplier", b =>
                {
                    b.HasOne("resturant.Models.Manager", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("resturant.Models.SupplyingInvoice", b =>
                {
                    b.HasOne("resturant.Models.Supplying", "Supplying")
                        .WithMany()
                        .HasForeignKey("SupplyingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplying");
                });

            modelBuilder.Entity("resturant.Models.SupplyingProcess", b =>
                {
                    b.HasOne("resturant.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("resturant.Models.Supplying", "Supplying")
                        .WithMany()
                        .HasForeignKey("SupplyingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Supplier");

                    b.Navigation("Supplying");
                });
#pragma warning restore 612, 618
        }
    }
}
