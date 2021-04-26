using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Database.DAL
{
    public class ShoppingCart
    {
        /// <summary>
        /// Идентификатор корзины
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Список продуктов
        /// </summary>
        private ICollection<Product> Products { get; set; }
    }
}
