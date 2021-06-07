using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleStore.Database.DAL;
using SimpleStore.Database.DAL.Enums;
using SimpleStore.Database.Enums;


namespace SimpleStore.Database
{
    public sealed class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        /// <summary>
        /// Таблица пользователей сайта
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Таблица ролей пользователей
        /// </summary>
        public DbSet<UserRole> Roles { get; set; }

        /// <summary>
        /// Таблица продуктов
        /// </summary>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// Таблица заказов
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Категории продуктов
        /// </summary>
        public DbSet<ProductCategory> Categories { get; set; }

        /// <summary>
        /// Отзывы о товарах
        /// </summary>
        public DbSet<ProductReview> Reviews { get; set; }

        /// <summary>
        /// Таблица  с информацией о фотографиях
        /// </summary>
        public DbSet<ProductImage> ProductPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
            
            modelBuilder.Entity<UserRole>()
                .Property(r=>r.Role)
                .HasConversion(
                    v => v.ToString(),
                    v => (Role)Enum.Parse(typeof(Role), v));

            modelBuilder.Entity<ProductCategory>()
                .Property(pc => pc.Category)
                .HasConversion(
                    v => v.ToString(),
                    v => (Category)Enum.Parse(typeof(Category), v));
            
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Products)
                .WithOne(sp => sp.Order)
                .HasForeignKey(sp => sp.OrderId);

            modelBuilder.Entity<Order>()
                .Property(o => o.State)
                .HasConversion(
                    v => v.ToString(),
                    v => (OrderState)Enum.Parse(typeof(OrderState), v));

            SeedUserRoles(modelBuilder);
            SeedProductCategories(modelBuilder);

        }

        /// <summary>
        /// Сидирование категорий продуктов
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SeedProductCategories(ModelBuilder modelBuilder)
        {
            var categories = new List<ProductCategory>()
            {
                new ProductCategory() {Id = 1, Category = Category.Books},
                new ProductCategory() {Id = 2, Category = Category.Electronics},
                new ProductCategory() {Id = 3, Category = Category.Wear},
                new ProductCategory() {Id = 4, Category = Category.Sports},
                new ProductCategory() {Id = 5, Category = Category.Footwear},
            };
            modelBuilder.Entity<ProductCategory>().HasData(categories);
        }

        /// <summary>
        /// Cидирование ролей
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SeedUserRoles(ModelBuilder modelBuilder) 
        {
            var userRoles = new List<UserRole>()
            {
                new UserRole() {Id = 1, Role = Role.User},
                new UserRole() {Id = 2, Role = Role.Admin}
            };
            modelBuilder.Entity<UserRole>().HasData(userRoles);
        }
    }
}
