using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleStore.Database;
using SimpleStore.Database.DAL;

namespace SimpleStore.Models.Misc
{
    public class DefaultProductInitializer
    {
        /// <summary>
        /// Инициализация базы данных дефолтными  продуктов (100 штук)
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(StoreContext context)
        {
            var random = new Random(DateTime.Now.Millisecond);
            for (var i = 0; i < 100; i++)
            {
                var product = new Product();

                product.Name = $"Product #{i+1}";
                product.Description = $"Test description product #{i+1}";
                product.Discount = random.Next(0, 10);
                var price = random.NextDouble();
                product.Price = (price != 0.0 ? price : 0.3) * 1000;
                var review = new ProductReview();
            }
            
            context.SaveChanges();
        }
    }
}
