﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SimpleStore.Database;

namespace SimpleStore.Database.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20210602180532_InitMigrate")]
    partial class InitMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("SimpleStore.Database.DAL.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("FinalPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<double>("Discount")
                        .HasColumnType("double precision");

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<int?>("ShoppingCartId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ImageId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ProductCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ImagePath")
                        .HasColumnType("text");

                    b.Property<int>("Title")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("ProductPhotos");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ProductReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductRate")
                        .HasColumnType("integer");

                    b.Property<string>("Review")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("FinalPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("NickName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("ProfileId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Role = "user"
                        },
                        new
                        {
                            Id = 2,
                            Role = "admin"
                        });
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.Order", b =>
                {
                    b.HasOne("SimpleStore.Database.DAL.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.Product", b =>
                {
                    b.HasOne("SimpleStore.Database.DAL.ProductCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleStore.Database.DAL.ProductImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleStore.Database.DAL.Order", null)
                        .WithMany("Products")
                        .HasForeignKey("OrderId");

                    b.HasOne("SimpleStore.Database.DAL.ShoppingCart", null)
                        .WithMany("Products")
                        .HasForeignKey("ShoppingCartId");

                    b.Navigation("Category");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ProductReview", b =>
                {
                    b.HasOne("SimpleStore.Database.DAL.Product", null)
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");

                    b.HasOne("SimpleStore.Database.DAL.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ShoppingCart", b =>
                {
                    b.HasOne("SimpleStore.Database.DAL.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.User", b =>
                {
                    b.HasOne("SimpleStore.Database.DAL.UserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("SimpleStore.Database.DAL.UserProfile", "Profile", b1 =>
                        {
                            b1.Property<int>("UserId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("City")
                                .HasColumnType("text");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.Property<string>("PhoneNumber")
                                .HasColumnType("text");

                            b1.Property<int>("ProfileId")
                                .HasColumnType("integer");

                            b1.Property<string>("Street")
                                .HasColumnType("text");

                            b1.Property<string>("Surname")
                                .HasColumnType("text");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner("User")
                                .HasForeignKey("UserId");

                            b1.Navigation("User");
                        });

                    b.Navigation("Profile");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.Order", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("SimpleStore.Database.DAL.ShoppingCart", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
