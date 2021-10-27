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
    public class SizesController : Controller
    {
        private MyDbContext _context;

        public SizesController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get() {
            var sizes = _context.Sizes.Select(i => new {
                i.Id,
                i.Name,
                i.Weight,
                i.Volumn
            });
            return Json(await sizes.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Size();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Sizes.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Sizes.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Sizes.FirstOrDefaultAsync(item => item.Id == key);

            _context.Sizes.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Size model, IDictionary values) {
            string ID = nameof(Size.Id);
            string NAME = nameof(Size.Name);
            string WEIGHT = nameof(Size.Weight);
            string VOLUMN = nameof(Size.Volumn);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(WEIGHT)) {
                model.Weight = values[WEIGHT] != null ? Convert.ToDouble(values[WEIGHT], CultureInfo.InvariantCulture) : (double?)null;
            }

            if(values.Contains(VOLUMN)) {
                model.Volumn = values[VOLUMN] != null ? Convert.ToDouble(values[VOLUMN], CultureInfo.InvariantCulture) : (double?)null;
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