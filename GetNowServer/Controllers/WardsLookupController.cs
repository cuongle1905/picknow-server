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
    public class WardsLookupController : Controller
    {
        private MyDbContext _context;

        public WardsLookupController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            var wards = _context.Wards.Select(i => new
            {
                i.Id,
                i.Name,
                i.District,
                i.Code
            });
            var ret = DataSourceLoader.Load(wards, loadOptions);
            return ret;
        }
    }
}
