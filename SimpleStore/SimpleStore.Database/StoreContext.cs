using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Database.DAL;

namespace SimpleStore.Database
{
    public sealed class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var roles = new List<UserRole>()
            {
                new UserRole(){Id = 1,Role="user"},
                new UserRole(){Id = 2,Role="admin"},
            };
            modelBuilder.Entity<UserRole>().HasData(roles);
            var adminProfile = new UserProfile()
            {
                Name = "Admin",
                Surname = "Admin",
                City = "Моксва",
                Street = "Пушкино",
                PhoneNumber = "+77777777777",
            };
            var userProfile = new UserProfile()
            {
                Name = "User",
                Surname = "User",
                City = "Кстово",
                Street = "Жуковского",
                PhoneNumber = "+77777777777",
            };
            var admin = new User()
            {
                Id = 1,
                Email = "admin@admin.ru",
                NickName = "admin",
                Password = "admin",
                Profile = adminProfile,
                Role = roles[1],
                RoleId = roles[1].Id
            };
            var simpleUser = new User()
            {
                Id = 2,
                Email = "user@user.ru",
                NickName = "user",
                Password = "user",
                Profile = userProfile,
                Role = roles[0],
                RoleId = roles[0].Id
            };
            modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
            modelBuilder.Entity<User>().HasData(admin, simpleUser);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductCategory> Categories { get; set; }
        public DbSet<ShoppingCart> Carts { get; set; }
        public DbSet<ProductReview> Reviews { get; set; }
        public DbSet<ProductImage> ProductPhotos { get; set; }

    }
}
