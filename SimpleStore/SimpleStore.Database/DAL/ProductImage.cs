using Microsoft.EntityFrameworkCore.Design;

namespace SimpleStore.Database.DAL
{
    public class ProductImage
    {
        /// <summary>
        /// Идентификатор изображения
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название изображения
        /// </summary>
        /// todo: миграцию сделать 1
        public string Title { get; set; }
        
        /// <summary>
        /// Путь до изображения относительно сервера
        /// </summary>
        public string ImagePath { get; set; }
        
        /// <summary>
        /// Идентификатор продукта
        /// </summary>
        public int ProductId { get; set; }
        
        /// <summary>
        /// Навигационное свойстов продукта
        /// </summary>
        public Product Product { get; set; }
        
    }
}
