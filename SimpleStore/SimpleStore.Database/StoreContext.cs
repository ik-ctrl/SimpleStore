using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleStore.Database.DAL;


namespace SimpleStore.Database
{
    public sealed class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new List<UserRole>()
            {
                new UserRole(){Id = 1,Role="user"},
                new UserRole(){Id = 2,Role="admin"},
            };
            modelBuilder.Entity<UserRole>().HasData(roles);

            modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
        }
        
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

    }
}
