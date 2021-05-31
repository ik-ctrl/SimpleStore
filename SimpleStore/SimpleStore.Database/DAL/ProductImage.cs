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
        public int Title { get; set; }
        
        /// <summary>
        /// Путь до изображения относительно сервера
        /// </summary>
        public string ImagePath { get; set; }
        
    }
}
