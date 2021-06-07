using System.Collections.Generic;

namespace SimpleStore.Database.DAL
{
    public class Product
    {
        /// <summary>
        /// Идентификатор товара
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название товара
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание товара
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Цена товара
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Скидка на товар
        /// </summary>
        public double Discount { get; set; }
        
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryId { get; set; }
        
        /// <summary>
        /// Навигационное свойство категории
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Количества товаров на складе
        /// </summary>
        public int ProductCount { get; set; }

        /// <summary>
        /// Список отзывов о товаре
        /// </summary>
        public ICollection<ProductReview> Reviews { get; set; }
        
        /// <summary>
        /// Изобрадения продукта
        /// </summary>
        public ICollection<ProductImage> Images { get; set; }
    }
}
