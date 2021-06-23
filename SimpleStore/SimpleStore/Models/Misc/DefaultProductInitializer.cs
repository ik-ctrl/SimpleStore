using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleStore.Database;
using SimpleStore.Database.DAL;
using SimpleStore.Database.DAL.Enums;
using SimpleStore.Database.Enums;

namespace SimpleStore.Models.Misc
{
    public class DefaultProductInitializer
    {
        /// <summary>
        /// Инициализация базы данных дефолтными записями  продуктов (100 штук)
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(StoreContext context)
        {
            var random = new Random(DateTime.Now.Millisecond);
            for (var productIndex = 0; productIndex < 100; productIndex++)
            {
                var product = new Product();

                product.Name = $"Product #{productIndex + 1}";
                product.Description = $"Test description product #{productIndex + 1}";
                product.Discount = random.Next(0, 10);
                product.ProductCount = random.Next(1000, 2000);

                var price = random.NextDouble();
                product.Price = (price != 0.0 ? price : 0.3) * 1000;


                var categoryTypeNumber = new int[] { 0, 10, 20, 30, 40 };
                product.Category = new ProductCategory()
                {
                    Category = (Category)categoryTypeNumber[random.Next(0, 4)],
                };

                var images = new List<ProductImage>();
                for (var imageIndex = 1; imageIndex <= 3; imageIndex++)
                {
                    var image = new ProductImage()
                    {
                        Title = $"Test title #{productIndex}",
                        ImagePath = $@"~/image/products/default/def_product_{imageIndex}_300px.png",
                        Product = product
                    };
                    images.Add(image);
                }
                product.Images = images;

                var reviews = new List<ProductReview>();
                var user = context.Users.FirstOrDefault(u => u.Role.Role.Equals(Role.User));
                if (user != null)
                {
                    for (var reviewIndex = 0; reviewIndex <= random.Next(3 - 5); reviewIndex++)
                    {
                        var review = new ProductReview()
                        {
                            User = user,
                            Review = $"Test product review #{reviewIndex}",
                            ProductRate = random.Next(1, 5),
                            Product = product,
                        };
                        reviews.Add(review);
                    }
                }
                product.Reviews = reviews;
                context.Products.Add(product);
            }

            context.SaveChanges();
        }
    }
}
