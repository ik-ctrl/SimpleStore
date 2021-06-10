namespace SimpleStore.Database.DAL
{
    //todo:
    //todo:исправить модель нужно. убрать id
    public class UserProfile
    {
        /// <summary>
        /// Идентификатор карточки информации
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }
        
        /// <summary>
        /// Номер телефона пользователя
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// Город доставки 
        /// </summary>
        public string City { get; set; }
        
        /// <summary>
        /// Улица доставки
        /// </summary>
        public string Street { get; set; }
        
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }
        
        /// <summary>
        /// Навигационное свойство на пользователя
        /// </summary>
        public User User { get; set; }
    }
}
