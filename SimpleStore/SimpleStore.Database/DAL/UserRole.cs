using SimpleStore.Database.DAL.Enums;

namespace SimpleStore.Database.DAL
{
    public class UserRole
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Название роли
        /// </summary>
        public Role Role { get; set; }
    }
}
