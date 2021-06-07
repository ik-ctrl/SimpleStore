using System.Collections.Generic;
using SimpleStore.Database.DAL.Enums;

namespace SimpleStore.Database.DAL
{
    public class Order
    {
        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Список продуктов
        /// </summary>
        public ICollection<SelectedProduct> Products { get; set; }

        /// <summary>
        /// Финальная цена
        /// </summary>
        public double FinalPrice { get; set; }
        
        /// <summary>
        /// Состояние заказа
        /// </summary>
        public OrderState State { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Навигационное свойство пользователя
        /// </summary>
        public User User { get; set; }
    }
}
