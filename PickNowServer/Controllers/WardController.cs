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
    public class WardController : ControllerBase
    {
        private MyDbContext myDbContext;

        public WardController(MyDbContext context)
        {
            myDbContext = context;
        }

        [HttpPost]
        public IList<Ward> GetWards(GetWardsRequestBody requestBody)
        {
            if (requestBody.district_id > 0)
                return (this.myDbContext.Wards.Where(e => e.District == requestBody.district_id).ToList());

            if (requestBody.province_id > 0)
            {
                var districtIds = this.myDbContext.Districts.Where(x => x.Province == requestBody.province_id).Select(e => e.Id);

                return (this.myDbContext.Wards.Where(e => districtIds.Contains(e.District)).ToList());
            }

            return (this.myDbContext.Wards.ToList());
        }

    }
}
