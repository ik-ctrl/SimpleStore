using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleStore.Areas.Store.Controllers
{
    [Area("Store")]
    public class MainController:Controller
    {
        [Route("[area]")]
        [Route("[area]/[controller]")]
        [Route("[area]/[controller]/[action]")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
