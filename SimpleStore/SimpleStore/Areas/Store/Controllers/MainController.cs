using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SimpleStore.Database;
using SimpleStore.Database.DAL;
using SimpleStore.Models.Enums;
using SimpleStore.Models.Misc;
using SimpleStore.Models.Services;
using SimpleStore.ViewModels.StoreViewModels;

namespace SimpleStore.Areas.Store.Controllers
{
    [Area("Store")]
    public class MainController : Controller
    {
        //todo: зачем передавать сюда контекст  если вся работа происходит через сервисы
        private readonly StoreContext _context;

        private readonly ILogger<MainController> _logger;
        private readonly ProductService _productService;
        private readonly IConfigurationSection _settings;

        public MainController(StoreContext context, ILogger<MainController> logger, ProductService productService, IConfiguration config)
        {
            _context = context;
            _logger = logger;
            _productService = productService;
            _settings = config.GetSection("AppSettings");
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
        public IActionResult Getproducts(int? pageNumber)
        {
            var currentPage = 1;
            var previousPage = 0;
            var finalPageNumber = currentPage;

            if (pageNumber.HasValue && pageNumber != 1)
            {
                currentPage = pageNumber.Value;
                previousPage = currentPage - 1;
            }

            IEnumerable<Product> products;
            try
            {
                products = _productService.GetProductPage(previousPage, 10);
                finalPageNumber = _productService.GetLastPageNumber(10);
            }
            catch (Exception ex)
            {
                _logger.LogError("Не удалось сформировать список товаров.", ex);
                products = new List<Product>();
            }

            //todo: поработать над названиями
            var productsViewModels = ModelConverter.ProductsToProductViewModels(products);
            var indexViewModel = new ProductsViewModel(productsViewModels, currentPage, finalPageNumber);
            return View("GetProducts", indexViewModel);
        }

        [HttpGet]
        [Route("[area]/[controller]/[action]/{type}/{text}/{page?}")]
        public IActionResult GetFilteredProducts(ProductCategoryEnum type, string text, int? pageNumber)
        {
            //    var searchingText = string.Empty;
            //    var productType = ProductCategoryEnum.All;
            //    var filteredProducts = new List<Product>();

            //    if (!string.IsNullOrEmpty(text.Trim()))
            //        searchingText = text.Trim();


            //    if (!type.Equals(ProductCategoryEnum.All))
            //        productType = type;

            //    if (productType != ProductCategoryEnum.All)
            //    {


            //    }
            //    else
            //    {
            //        if(!string.IsNullOrEmpty(searchingText))
            //            //todo:то фильтруем
            //    }


            //        //1. проверка на тип продукта
            ////  а. все продукты -> text  ищет по всем продуктам и формирует страницы
            ////  б. определенный тип продутка -> text  ищет только в опредленной группе
            ////2. проверка на текст. 
            ////  а. пришел текст пустой или  null-> формируем список товаров по группе
            ////  б. что то помиио null-> формируем список товаров по группе и тексту
            ////3. пришла страница
            ////  а. страница null-> отдаём первые 10 товаров
            ////  б. страница !=null->формируем с нужной страницы товары

            var vm = new ProductsViewModel(new List<ProductViewModel>(),1,2);
        return View("GetProducts",vm);
        }
    }
}
