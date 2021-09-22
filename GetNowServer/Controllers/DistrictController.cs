using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GetNowServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetNowServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private MyDbContext myDbContext;

        public DistrictController(MyDbContext context)
        {
            myDbContext = context;
        }

        [HttpPost]
        public IList<District> GetDistricts(GetDistrictsRequestBody requestBody)
        {
            if (requestBody.province_id > 0)
                return (this.myDbContext.Districts.Where(e => e.Province == requestBody.province_id).ToList());

            return (this.myDbContext.Districts.ToList());
        }
    }
}
