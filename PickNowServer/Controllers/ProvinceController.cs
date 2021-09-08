using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickNowServer.DbContexts;
using PickNowServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNowServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private MyDbContext myDbContext;

        public ProvinceController(MyDbContext context)
        {
            myDbContext = context;
        }

        [HttpPost]
        public IList<Province> Post()
        {
            return (this.myDbContext.Provinces.ToList());
        }
    }
}
