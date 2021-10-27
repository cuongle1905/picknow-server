using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GetNowServer.Models;

namespace GetNowServer.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BrandsController : Controller
    {
        private MyDbContext _context;

        public BrandsController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var brands = _context.Brands.Select(i => new {
                i.Id,
                i.Name,
                i.Parent
            });
            return Json(await brands.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Brand();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Brands.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Brands.FirstOrDefaultAsync(item => item.Id == key);
            if(model == null)
                return StatusCode(409, "Object not found");

            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task Delete(int key) {
            var model = await _context.Brands.FirstOrDefaultAsync(item => item.Id == key);

            _context.Brands.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Brand model, IDictionary values) {
            string ID = nameof(Brand.Id);
            string NAME = nameof(Brand.Name);
            string PARENT = nameof(Brand.Parent);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(PARENT)) {
                model.Parent = values[PARENT] != null ? Convert.ToInt32(values[PARENT]) : (int?)null;
            }
        }

        private string GetFullErrorMessage(ModelStateDictionary modelState) {
            var messages = new List<string>();

            foreach(var entry in modelState) {
                foreach(var error in entry.Value.Errors)
                    messages.Add(error.ErrorMessage);
            }

            return String.Join(" ", messages);
        }
    }
}