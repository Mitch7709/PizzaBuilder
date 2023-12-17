﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBuilder.Data;

#nullable disable

namespace PizzaBuilder.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PizzaBuilder.Models.Crust", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Crusts");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("PizzaBuilder.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Base_Price")
                        .HasColumnType("float");

                    b.Property<int>("CrustID")
                        .HasColumnType("int");

                    b.Property<string>("Instructions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CrustID");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Topping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaBuilder.Models.ToppingsToPizza", b =>
                {
                    b.Property<int>("PizzaID")
                        .HasColumnType("int");

                    b.Property<int>("ToppingID")
                        .HasColumnType("int");

                    b.HasKey("PizzaID", "ToppingID");

                    b.HasIndex("ToppingID");

                    b.ToTable("ToppingsToPizzas");
                });

            modelBuilder.Entity("PizzaBuilder.Models.OrderItem", b =>
                {
                    b.HasOne("PizzaBuilder.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBuilder.Models.Pizza", "Pizza")
                        .WithMany()
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Pizza");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Pizza", b =>
                {
                    b.HasOne("PizzaBuilder.Models.Crust", "Crust")
                        .WithMany("Pizzas")
                        .HasForeignKey("CrustID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crust");
                });

            modelBuilder.Entity("PizzaBuilder.Models.ToppingsToPizza", b =>
                {
                    b.HasOne("PizzaBuilder.Models.Pizza", "Pizza")
                        .WithMany("ToppingsToPizzas")
                        .HasForeignKey("PizzaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBuilder.Models.Topping", "Topping")
                        .WithMany("ToppingsToPizzas")
                        .HasForeignKey("ToppingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pizza");

                    b.Navigation("Topping");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Crust", b =>
                {
                    b.Navigation("Pizzas");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Pizza", b =>
                {
                    b.Navigation("ToppingsToPizzas");
                });

            modelBuilder.Entity("PizzaBuilder.Models.Topping", b =>
                {
                    b.Navigation("ToppingsToPizzas");
                });
#pragma warning restore 612, 618
        }
    }
}
