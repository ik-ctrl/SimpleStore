using System;
using System.Collections.Generic;
using System.Linq;
using SimpleStore.Database;
using SimpleStore.Database.DAL;
using SimpleStore.Database.DAL.Enums;
using SimpleStore.Database.Enums;

namespace SimpleStore.Models.Misc.DbInitializers
{
    public class DefaultProductInitializer: IInitializer
    {
        /// <summary>
        /// Инициализация базы данных дефолтными записями  продуктов (100 штук)
        /// </summary>
        /// <param name="context"></param>
        public  void Initialize(StoreContext context)
        {
            var randomizer = new Random(DateTime.Now.Millisecond);
            for (var productIndex = 0; productIndex < 173; productIndex++)
            {
                var product = GenerateProduct(productIndex,randomizer);
                product.Images = GenerateProductImages(product,productIndex);
                product.Reviews = GenerateProductReviews(context, randomizer, product);
                context.Products.Add(product);
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Генерация дефолтного продукта с  некоторыми рандомными настройками
        /// </summary>
        /// <param name="productIndex">Номер продукта в очереди</param>
        /// <param name="randomizer">Механизм для рандомизации</param>
        /// <returns>Возвращает продукт с настройками(без фотографий и отзывов)</returns> 
        private  Product GenerateProduct(int productIndex,Random randomizer)
        {

            var price = randomizer.NextDouble();
            var categoryTypeNumber = new int[] { 0, 10, 20, 30, 40 };
            return new Product()
            {
                Name = $"Product #{productIndex + 1}",
                Description = $"Test description product #{productIndex + 1}",
                Discount = randomizer.Next(0, 10),
                ProductCount = randomizer.Next(1000, 2000),
                Price = (price != 0.0 ? price : 0.3) * 1000,
                Category = new ProductCategory()
                {
                    Category = (Category)categoryTypeNumber[randomizer.Next(0, 4)],
                }
            };
        }

        /// <summary>
        /// Генерирует отзывы для продукта
        /// </summary>
        /// <param name="context">Контекст БД для изъятия простого юзера</param>
        /// <param name="random"> Механизм рандомизации</param>
        /// <param name="product">Продукт, к которуму нужно сгенерировать отзывы</param>
        /// <returns> Коллекция отзывов о продукте</returns>
        private  ICollection<ProductReview> GenerateProductReviews(StoreContext context, Random random, Product product)
        {
            var user = context.Users.FirstOrDefault(u => u.Role.Role.Equals(Role.User));
            var reviews = new List<ProductReview>();
            if (user != null)
            {
                for (var reviewIndex = 0; reviewIndex <= random.Next(2 , 5); reviewIndex++)
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
            return reviews;
        }

        /// <summary>
        /// Генерирование записей о изображении объекта
        /// </summary>
        /// <param name="product">Продукт , к которуму необходимо сгененрировать изображения</param>
        /// <param name="productIndex">Номер проюдукта</param>
        /// <returns>Коллекцию дефолтных изображений для продукта</returns>
        private  ICollection<ProductImage> GenerateProductImages(Product product, int productIndex)
        {
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

            return images;
        }
    }
}
