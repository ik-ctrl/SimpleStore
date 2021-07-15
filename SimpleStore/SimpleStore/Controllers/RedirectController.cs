using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimpleStore.Controllers
{

    //todo: снести этот контроллер. чтобы потом сразу было направление на  сторе
    public class RedirectController : Controller
    {
        private readonly ILogger<RedirectController> _logger;

        public RedirectController(ILogger<RedirectController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        ///  Метод для перенаправления на основную страницу магазина
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            try
            {
                return Redirect("store/main/getproducts");
            }
            catch (Exception ex)
            {
                _logger.LogError("Redirect is fail", ex);
                throw;
            }

        }
    }
}
