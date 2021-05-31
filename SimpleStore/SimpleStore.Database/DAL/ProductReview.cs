namespace SimpleStore.Database.DAL
{
    public class ProductReview
    {
        /// <summary>
        /// Идентификатор отзыва
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Пользовательская оценка
        /// </summary>
        public int ProductRate { get; set; }
        
        /// <summary>
        /// Пользовательский отзыв
        /// </summary>
        public string Review { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int? UserId { get; set; }
        
        /// <summary>
        ///  Пользовательские данные
        /// </summary>
        public User User { get; set; }
    }
}
