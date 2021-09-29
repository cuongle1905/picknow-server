using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetNowServer.Controllers
{
    [Route("[controller]/[action]")]
    public class ViewComponentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StoreProducts(int id)
        {
            return ViewComponent("StoreProductsViewComponent", new { id });
        }
    }
}
