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
    [Migration("20221021083615_addtbtype")]
    partial class addtbtype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("API.Data.Product", b =>
                {
                    b.Property<Guid>("Id")
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

                    b.HasKey("Id");

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

            modelBuilder.Entity("API.Data.Product", b =>
                {
                    b.HasOne("API.Data.TypeProduct", "TypeProduct")
                        .WithMany("Products")
                        .HasForeignKey("TypeId");

                    b.Navigation("TypeProduct");
                });

            modelBuilder.Entity("API.Data.TypeProduct", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}