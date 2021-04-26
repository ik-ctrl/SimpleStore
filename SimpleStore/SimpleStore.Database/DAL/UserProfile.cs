using System.Net.Sockets;

namespace SimpleStore.Database.DAL
{
    public class UserProfile
    {
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
    }
}
