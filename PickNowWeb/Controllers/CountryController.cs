using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickNowWeb.DbContexts;
using PickNowWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickNowWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private MyDbContext myDbContext;

        public CountryController(MyDbContext context)
        {
            myDbContext = context;
        }

        //[HttpGet]
        //public IList<Country> Get()
        //{
        //    return (this.myDbContext.Countries.ToList());
        //}

        [HttpPost]
        public IList<Country> Post()
        {
            return (this.myDbContext.Countries.ToList());
        }
    }
}
