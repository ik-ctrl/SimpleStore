namespace SimpleStore.Database.DAL
{
    public class User
    {
        /// <summary>
        /// Идентификатор пользователя 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Почта пользователя
        /// </summary>
        public string Email { get; set; }
        
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Ник пользователя
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// Содержит информацию о пользователе
        /// </summary>
        public UserProfile Profile { get; set; }
        
        /// <summary>
        /// Идентификатор роли пользователя
        /// </summary>
        public int RoleId { get; set; }
        
        /// <summary>
        /// Навигационное свойство для роли
        /// </summary>
        public UserRole Role { get; set; }
        
    }
}
