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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
            modelBuilder.Entity<ProductCategory>()
                .Property(pc => pc.Category)
                .HasConversion(
                    v => v.ToString(),
                    v => (CategoryEnum)Enum.Parse(typeof(CategoryEnum), v));

            SeedProductCategories(modelBuilder);
            SeedUserRoles(modelBuilder);

            var adminRole = new UserRole() { Id = 1, Role = "user" };

            var userRole = new UserRole() { Id = 2, Role = "admin" };

            var user = new User()
            {
                Id = 0,
                NickName = "user",
                Email = "user@user.ru",
                Password = GetHashFromSalPassword("user","user"),
                Role = userRole,
                RoleId = userRole.Id
            };

            var userProfile = new UserProfile()
            {
                Id = 0,
                City = "Кстово",
                Name = "Илья",
                Surname = "Оконовц",
                PhoneNumber = "88005553535",
                Street = "Жуковского",
                User = user,
                UserId = user.Id
            };

            user.ProfileId = userProfile.Id;
            user.Profile = userProfile;


            var admin = new User()
            {
                Id = 1,
                NickName = "admin",
                Email = "admin@admin.ru",
                Password = GetHashFromSalPassword("admin", "admin"),
                Role = adminRole,
                RoleId = adminRole.Id
            };

            var adminProfile = new UserProfile()
            {
                Id = 1,
                City = "Нижний Новгород",
                Name = "Илья",
                Surname = "Оконов",
                PhoneNumber = "88005553535",
                Street = "Энчпочмакова",
                User = admin,
                UserId = admin.Id
            };
            admin.ProfileId = adminProfile.Id;
            admin.Profile = adminProfile;

            modelBuilder.Entity<User>().OwnsOne(u => u.Profile).HasData(user, admin);



        }

        #region Helps methods
        /// <summary>
        /// Сидирование категорий продуктов
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SeedProductCategories(ModelBuilder modelBuilder)
        {
            var categories = new List<ProductCategory>()
            {
                new ProductCategory() {Id = 0, Category = CategoryEnum.Books},
                new ProductCategory() {Id = 1, Category = CategoryEnum.Electronics},
                new ProductCategory() {Id = 2, Category = CategoryEnum.Wear},
                new ProductCategory() {Id = 3, Category = CategoryEnum.Sports},
                new ProductCategory() {Id = 4, Category = CategoryEnum.Footwear},
            };
            modelBuilder.Entity<ProductCategory>().HasData(categories);
        }

        /// <summary>
        /// Cидирование ролей
        /// </summary>
        /// <param name="modelBuilder"></param>
        private void SeedUserRoles(ModelBuilder modelBuilder)
        {
            var roles = new List<UserRole>()
            {
                new UserRole() {Id = 1, Role = "user"},
                new UserRole() {Id = 2, Role = "admin"},
            };
            modelBuilder.Entity<UserRole>().HasData(roles);
        }


        //todo: возможно стоит вынести в главный проект
        /// <summary>
        /// Получить хэщ засоленного пароля
        /// </summary>
        /// <param name="password">пароль</param>
        /// <param name="salt">соль</param>
        /// <returns>Возвращает хэш засоленного пароля в нижнем регистре </returns>
        private string GetHashFromSalPassword(string password, string salt)
        {
            var checkArguments = string.IsNullOrEmpty(password) || string.IsNullOrEmpty(salt);
            Contract.Requires<ArgumentNullException>(!checkArguments, "Password or salt is null");
            var saltPassword = password + salt;
            string resultHash;
            using (var shaManager = new SHA256Managed())
            {
                var bytes = Encoding.UTF8.GetBytes(saltPassword);
                var hash = shaManager.ComputeHash(bytes);
                resultHash = BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
            return resultHash;
        }


        #endregion



    }
}
