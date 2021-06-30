using System.Collections.Generic;
using System.Linq;
using SimpleStore.Database;
using SimpleStore.Database.DAL;

namespace SimpleStore.Models.Services
{
    public class ProductService
    {
        private readonly StoreContext _context;

        public ProductService(StoreContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Формирует список из 10 товаров
        /// </summary>
        /// <param name="displayedProducts">Количество отображаемых продуктов</param>
        /// <param name="previousPageNumber">Предыдущая страница</param>
        /// <returns>Список из 10 товаров</returns>
        public IEnumerable<Product> GetProductPage(int previousPageNumber,int displayedProducts)
        {
            //await Task.Delay(10000);
            return  _context.Products.Skip(previousPageNumber* displayedProducts).Take(displayedProducts).ToList();
        }

        /// <summary>
        /// Возвращает номер последей страницы
        /// </summary>
        /// <param name="displayedProducts">Количество отображаемых продуктов</param>
        /// <returns>Номер последней страницы</returns>
        public int GetLastPageNumber(int displayedProducts)
        {
            //todo:  может стоит вынести в настройки  количество продуктов на странице
            var productCount =  _context.Products.Count();
            var finalPageNumber = productCount / displayedProducts;
            if (productCount % displayedProducts != 0)
            {
                finalPageNumber += 1;
            }
            return finalPageNumber;
        }

        //public void Dispose()
        //{
        //    _context?.Dispose();
        //}
    }
}
