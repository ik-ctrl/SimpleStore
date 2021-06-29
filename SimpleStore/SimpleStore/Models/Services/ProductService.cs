using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        /// <param name="currentPageNumber">Текущая страница</param>
        /// <param name="previousPageNumber">Предыдущая страница</param>
        /// <returns>Список из 10 товаров</returns>
        public async Task<IEnumerable<Product>> GetProductPage(int currentPageNumber, int previousPageNumber)
        {
            //await Task.Delay(10000);
            return await _context.Products.Skip(previousPageNumber*10).Take(10).ToListAsync();
        }

        /// <summary>
        /// Возвращает номер последей страницы
        /// </summary>
        /// <returns>Номер последней страницы</returns>
        public int GetLastPageNumber()
        {
            //todo:  может стоит вынести в настройки  количество продуктов на странице
            var productCount =  _context.Products.Count();
            var finalPageNumber = productCount / 10;
            if (productCount % 10 != 0)
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
