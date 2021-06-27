using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SimpleStore.Database;
using SimpleStore.Database.DAL;

namespace SimpleStore.Models.Services
{
    public class ProductService
    {
        private readonly StoreContext _context;
        private readonly ILogger<ProductService> _logger;
        
        public ProductService(StoreContext context,ILogger<ProductService> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает первую страницу товаров
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetFirstProductPage()
        {
            try
            {
                List<Product> products;
                await using (_context)
                {
                    await Task.Delay(100000);
                    products= _context.Products.Take(10).ToList();
                }
                return products;
            }
            catch (Exception e)
            {
                _logger.LogError("ну");
            }
        
        }

    }
}
