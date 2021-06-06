using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleStore.Database.DAL;
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
        /// Корзина пользователя
        /// </summary>
        public DbSet<ShoppingCart> Carts { get; set; }

        /// <summary>
        /// Отзывы о товарах
        /// </summary>
        public DbSet<ProductReview> Reviews { get; set; }

        /// <summary>
        /// Таблица  с информацией о фотографиях
        /// </summary>
        public DbSet<ProductImage> ProductPhotos { get; set; }

        //todo: добавить связь один ко многим для ShoppingCart и Orders
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
            modelBuilder.Entity<ProductCategory>()
                .Property(pc => pc.Category)
                .HasConversion(
                    v => v.ToString(),
                    v => (CategoryEnum)Enum.Parse(typeof(CategoryEnum), v));

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Reviews)
                .WithOne(r => r.Product)
                .HasForeignKey(r => r.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product)
                .HasForeignKey(i => i.ProductId);
            
            
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
                new ProductCategory() {Id = 1, Category = CategoryEnum.Books},
                new ProductCategory() {Id = 2, Category = CategoryEnum.Electronics},
                new ProductCategory() {Id = 3, Category = CategoryEnum.Wear},
                new ProductCategory() {Id = 4, Category = CategoryEnum.Sports},
                new ProductCategory() {Id = 5, Category = CategoryEnum.Footwear},
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
                new UserRole() {Id = 1, Role = "user"},
                new UserRole() {Id = 2, Role = "admin"}
            };
            modelBuilder.Entity<UserRole>().HasData(userRoles);
        }

    }
}
