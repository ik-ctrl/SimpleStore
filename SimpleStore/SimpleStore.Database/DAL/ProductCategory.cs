using SimpleStore.Database.Enums;

namespace SimpleStore.Database.DAL
{
    public class ProductCategory
    {
        /// <summary>
        /// Идентификатор категории
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Тип категории
        /// </summary>
        public CategoryEnum Category { get; set; }
    }
}
