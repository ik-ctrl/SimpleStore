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
        [Route("[area]/[controller]/[action]/{pageNumber?}")]
        public IActionResult Index(int? pageNumber)
        {
            //var needPage = 0;
            //var previuousPage = 0;

            //if (pageNumber.HasValue)
            //{
            //    needPage = pageNumber.Value;
            //    previuousPage = pageNumber.Value - 1;
            //}

            //var products= 
            return View();
        }
    }
}
