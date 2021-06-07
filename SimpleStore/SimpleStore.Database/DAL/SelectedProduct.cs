using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Database.DAL
{
    public class SelectedProduct
    {
        // <summary>
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
        /// Полная цена товара 
        /// </summary>
        public double FullPrice { get; set; }
        
        /// <summary>
        ///  Финальная цена товара
        /// </summary>
        public double FinalPrice { get; set; }

        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Навигационное свойство категории
        /// </summary>
        public ProductCategory Category { get; set; }

        /// <summary>
        /// Изобрадения продукта
        /// </summary>
        public ICollection<ProductImage> Images { get; set; }
        
        /// <summary>
        /// Идентификатор заказа 
        /// </summary>
        public int OrderId { get; set; }
        
        /// <summary>
        /// Навигационное свойство заказа
        /// </summary>
        public Order Order { get; set; }

        /// <summary>
        /// копия идентификатора товара (поиска фотографий). 
        /// </summary>
        public int ProductId { get; set; }
        
        
    }
}
