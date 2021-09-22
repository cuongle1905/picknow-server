using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PickNowWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PickNowWeb.Service;

namespace PickNowWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : Controller
    {
        private readonly IWardService _wardService;
        public WardController(IWardService wardService)
        {
            _wardService = wardService;
        }

        [HttpGet]
        [Route("[action]")]
        public IList<Ward> Get()
        {
            return _wardService.GetWards();
        }

        [HttpPost]
        public IList<Ward> GetWards(GetWardsRequestBody requestBody)
        {
            if (requestBody.district_id > 0)
                return _wardService.GetWardsByDistrictId(requestBody.district_id);
            if (requestBody.province_id > 0)
                return _wardService.GetWardsByProvinceId(requestBody.province_id);

            return _wardService.GetWards();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Add(Ward ward)
        {
            _wardService.AddWard(ward);
            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Update(Ward ward)
        {
            _wardService.UpdateWard(ward);
            return Ok();
        }

        [HttpDelete]
        [Route("[action]")]
        public IActionResult Delete(int id)
        {
            var existingWard = _wardService.GetWard(id);
            if (existingWard != null)
            {
                _wardService.DeleteWard(existingWard.Id);
                return Ok();
            }
            return NotFound($"Ward Not Found with ID: {id}");
        }
    }
}
