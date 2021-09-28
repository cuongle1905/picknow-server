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
    public class StoreProductGroupsController : Controller
    {
        private MyDbContext _context;

        public StoreProductGroupsController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var storeproductgroups = _context.StoreProductGroups.Select(i => new {
                i.Id,
                i.StoreGroup,
                i.Name,
                i.Parent
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;
            return Json(await DataSourceLoader.LoadAsync(storeproductgroups, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new StoreProductGroup();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            try
            {
                model.Id = _context.StoreProductGroups.Max(x => x.Id) + 1;
            }
            catch
            {
                model.Id = 1;
            }
            var result = _context.StoreProductGroups.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.StoreProductGroups.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.StoreProductGroups.FirstOrDefaultAsync(item => item.Id == key);

            _context.StoreProductGroups.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(StoreProductGroup model, IDictionary values) {
            string ID = nameof(StoreProductGroup.Id);
            string STORE_GROUP = nameof(StoreProductGroup.StoreGroup);
            string NAME = nameof(StoreProductGroup.Name);
            string PARENT = nameof(StoreProductGroup.Parent);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(STORE_GROUP)) {
                model.StoreGroup = Convert.ToInt32(values[STORE_GROUP]);
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