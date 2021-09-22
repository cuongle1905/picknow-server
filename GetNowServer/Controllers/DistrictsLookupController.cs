using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using PickNowWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNowWeb.Controllers
{
    [Route("api/[controller]/[action]")]
    public class DistrictsLookupController : Controller
    {
        private MyDbContext _context;

        public DistrictsLookupController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var districts = _context.Districts.Select(i => new
            {
                i.Id,
                i.Name,
                i.Province,
                i.Code
            });
            var ret = DataSourceLoader.Load(districts, loadOptions);
            return ret;
        }
    }
}
