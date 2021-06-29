using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleStore.Database;
using SimpleStore.Database.DAL;
using SimpleStore.Models.Misc;
using SimpleStore.Models.Services;
using SimpleStore.ViewModels.StoreViewModels;

namespace SimpleStore.Areas.Store.Controllers
{
    [Area("Store")]
    public class MainController:Controller
    {
        private readonly StoreContext _context;
        private readonly ILogger<MainController> _logger;
        private readonly ProductService _productService;

        public MainController(StoreContext context,ILogger<MainController> logger,ProductService productService)
        {
            _context = context;
            _logger = logger;
            _productService = productService;
        }
        
        /// <summary>
        /// Возвращает список из 10 продуктов в зависимости от страницы
        /// </summary>
        /// <param name="pageNumber">Номер необходимой страницы</param>
        /// <returns> Список из 10 продуктов без фильтров</returns>
        [HttpGet]
        [Route("[area]")]
        [Route("[area]/[controller]")]
        [Route("[area]/[controller]/[action]")]
        [Route("[area]/[controller]/[action]/{pageNumber?}")]
        public async Task<IActionResult> Index(int? pageNumber)
        {
            var currentPage = 1;
            var previousPage = 0;
            var finalPageNumber = currentPage;
            if (pageNumber.HasValue&&pageNumber!=1)
            {
                currentPage = pageNumber.Value;
                previousPage = currentPage - 1;
            }

            IEnumerable<Product> products;
            try
            {
                products = await _productService.GetProductPage(currentPage, previousPage);
                finalPageNumber = _productService.GetLastPageNumber();
            }
            catch (Exception ex)
            {
                _logger.LogError("Не удалось сформировать список товаров.",ex);
                products = new List<Product>();
            }
            
            var productsViewModels = ModelConverter.ProductsToProductViewModels(products);
            var indexViewModel = new IndexViewModel(productsViewModels, currentPage, finalPageNumber);
            return View(indexViewModel);
        }
    }
}
