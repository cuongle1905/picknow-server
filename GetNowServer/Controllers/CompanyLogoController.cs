using DevExtreme.AspNet.Mvc;
using GetNowServer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GetNowServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CompanyLogoController : Controller
    {
        private MyDbContext _context;

        public CompanyLogoController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<CompanyLogo>> Get()
        {
            return await _context.CompanyLogos.ToListAsync();
        }
    }
}
