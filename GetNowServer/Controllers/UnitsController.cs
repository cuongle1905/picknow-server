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
    public class UnitsController : Controller
    {
        private MyDbContext _context;

        public UnitsController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var units = _context.Units.Select(i => new
            {
                i.Id,
                i.Name,
                i.BaseUnit,
                i.Exchange
            });
            return Json(await units.ToListAsync());
        }
        //public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
        //    var units = _context.Units.Select(i => new {
        //        i.Id,
        //        i.Name,
        //        i.BaseUnit,
        //        i.Exchange
        //    });

        //    // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
        //    // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
        //    // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
        //    // loadOptions.PrimaryKey = new[] { "Id" };
        //    // loadOptions.PaginateViaPrimaryKey = true;

        //    return Json(await DataSourceLoader.LoadAsync(units, loadOptions));
        //}

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Unit();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Units.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Units.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Units.FirstOrDefaultAsync(item => item.Id == key);

            _context.Units.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(Unit model, IDictionary values) {
            string ID = nameof(Unit.Id);
            string NAME = nameof(Unit.Name);
            string BASE_UNIT = nameof(Unit.BaseUnit);
            string EXCHANGE = nameof(Unit.Exchange);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(BASE_UNIT)) {
                model.BaseUnit = values[BASE_UNIT] != null ? Convert.ToSByte(values[BASE_UNIT]) : (sbyte?)null;
            }

            if(values.Contains(EXCHANGE)) {
                model.Exchange = values[EXCHANGE] != null ? Convert.ToDouble(values[EXCHANGE], CultureInfo.InvariantCulture) : (double?)null;
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