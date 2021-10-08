using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetNowServer.Pages
{
    public class StoreProductsModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult LoadProducts(int productGroupId)
        {
            return ViewComponent("StoreProducts", new { productGroupId = productGroupId });
        }
    }
}
