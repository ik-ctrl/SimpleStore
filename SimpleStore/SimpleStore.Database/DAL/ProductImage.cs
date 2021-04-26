using System;
using System.Collections.Generic;
using System.Text;

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
        /// Картинка в байтах
        /// </summary>
        public byte[] ImageData { get; set; }
    }
}
