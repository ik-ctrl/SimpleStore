using Microsoft.EntityFrameworkCore;
using SimpleStore.Database.DAL;

namespace SimpleStore.Database
{
    public sealed class StoreContext:DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().OwnsOne(u => u.Profile);
            
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
