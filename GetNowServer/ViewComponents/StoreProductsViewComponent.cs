using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetNowServer
{
    [ViewComponent(Name = "StoreProductsViewComponent")]
    public class StoreProductsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            (string greeting, string name) data = ("Hello", "Donald Trump");
            return View(data);
        }
    }
}