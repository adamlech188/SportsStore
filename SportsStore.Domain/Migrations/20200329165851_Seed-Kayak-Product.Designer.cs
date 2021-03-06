﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SportsStore.Domain;

namespace SportsStore.Domain.Migrations
{
    [DbContext(typeof(SportsStoreContext))]
    [Migration("20200329165851_Seed-Kayak-Product")]
    partial class SeedKayakProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SportsStore.Domain.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Watersports"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Soccer"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Chess"
                        });
                });

            modelBuilder.Entity("SportsStore.Domain.Entities.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryId = 1,
                            Description = "A boat for one person",
                            Name = "Kayak",
                            Price = 275.00m
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryId = 1,
                            Description = "Protective and fashionable",
                            Name = "Lifejacket",
                            Price = 48.95m
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryId = 2,
                            Description = "FIFA-approved size and weight",
                            Name = "Soccer Ball",
                            Price = 19.50m
                        },
                        new
                        {
                            ProductID = 4,
                            CategoryId = 2,
                            Description = "Give your playing field a professional touch",
                            Name = "Corner Flags",
                            Price = 34.95m
                        },
                        new
                        {
                            ProductID = 5,
                            CategoryId = 2,
                            Description = "Flat-packed 35000-seat stadium",
                            Name = "Stadium",
                            Price = 79500m
                        },
                        new
                        {
                            ProductID = 6,
                            CategoryId = 3,
                            Description = "Improve your brain efficiency by 75%",
                            Name = "Thinking Cap",
                            Price = 16.00m
                        },
                        new
                        {
                            ProductID = 7,
                            CategoryId = 3,
                            Description = "Secretly give your opponent a disadvantage",
                            Name = "Unsteady Chair",
                            Price = 29.950m
                        },
                        new
                        {
                            ProductID = 8,
                            CategoryId = 3,
                            Description = "A fun game for the family",
                            Name = "Human Chess Board",
                            Price = 75.00m
                        },
                        new
                        {
                            ProductID = 9,
                            CategoryId = 1,
                            Description = "Gold-plated, diamond-studded King",
                            Name = "Bling-Bling King",
                            Price = 1200.00m
                        });
                });

            modelBuilder.Entity("SportsStore.Domain.Entities.Product", b =>
                {
                    b.HasOne("SportsStore.Domain.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
