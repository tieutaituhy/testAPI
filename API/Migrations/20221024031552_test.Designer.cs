﻿// <auto-generated />
using System;
using API.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221024031552_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Data.DetailOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<byte>("SaleOf")
                        .HasColumnType("tinyint unsigned");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("AppDetailOrder", (string)null);
                });

            modelBuilder.Entity("API.Data.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OrderDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValue(new DateTime(2022, 10, 24, 10, 15, 52, 568, DateTimeKind.Local).AddTicks(9465));

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Recipient")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("StatusOrder")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("AppOrder", (string)null);
                });

            modelBuilder.Entity("API.Data.Product", b =>
                {
                    b.Property<Guid>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("double");

                    b.Property<byte>("SaleOf")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int?>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("TypeId");

                    b.ToTable("AppProduct", (string)null);
                });

            modelBuilder.Entity("API.Data.TypeProduct", b =>
                {
                    b.Property<int?>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("TypeId");

                    b.ToTable("AppTypeProduct", (string)null);
                });

            modelBuilder.Entity("API.Data.DetailOrder", b =>
                {
                    b.HasOne("API.Data.Order", "Order")
                        .WithMany("DetailOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DetailOrder_Order");

                    b.HasOne("API.Data.Product", "Product")
                        .WithMany("DetailOrders")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_DetailOrder_Product");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Data.Product", b =>
                {
                    b.HasOne("API.Data.TypeProduct", "TypeProduct")
                        .WithMany("Products")
                        .HasForeignKey("TypeId");

                    b.Navigation("TypeProduct");
                });

            modelBuilder.Entity("API.Data.Order", b =>
                {
                    b.Navigation("DetailOrders");
                });

            modelBuilder.Entity("API.Data.Product", b =>
                {
                    b.Navigation("DetailOrders");
                });

            modelBuilder.Entity("API.Data.TypeProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
