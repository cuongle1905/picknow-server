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
    public class StoresController : Controller
    {
        private MyDbContext _context;

        public StoresController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var stores = _context.Stores.Select(i => new {
                i.Id,
                i.Name,
                i.Province,
                i.District,
                i.Ward,
                i.Address,
                i.Company,
                i.ContactName,
                i.ContactPhone,
                i.ContactPhone2,
                i.Website
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(stores, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Store();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Stores.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(int key, string values) {
            var model = await _context.Stores.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.Stores.FirstOrDefaultAsync(item => item.Id == key);

            _context.Stores.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> CompaniesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Companies
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> DistrictsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Districts
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> ProvincesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Provinces
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> WardsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Wards
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Store model, IDictionary values) {
            string ID = nameof(Store.Id);
            string NAME = nameof(Store.Name);
            string PROVINCE = nameof(Store.Province);
            string DISTRICT = nameof(Store.District);
            string WARD = nameof(Store.Ward);
            string ADDRESS = nameof(Store.Address);
            string COMPANY = nameof(Store.Company);
            string CONTACT_NAME = nameof(Store.ContactName);
            string CONTACT_PHONE = nameof(Store.ContactPhone);
            string CONTACT_PHONE2 = nameof(Store.ContactPhone2);
            string WEBSITE = nameof(Store.Website);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt32(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(PROVINCE)) {
                model.Province = Convert.ToInt16(values[PROVINCE]);
            }

            if(values.Contains(DISTRICT)) {
                model.District = Convert.ToInt32(values[DISTRICT]);
            }

            if(values.Contains(WARD)) {
                model.Ward = Convert.ToInt32(values[WARD]);
            }

            if(values.Contains(ADDRESS)) {
                model.Address = Convert.ToString(values[ADDRESS]);
            }

            if(values.Contains(COMPANY)) {
                model.Company = values[COMPANY] != null ? Convert.ToInt32(values[COMPANY]) : (int?)null;
            }

            if(values.Contains(CONTACT_NAME)) {
                model.ContactName = Convert.ToString(values[CONTACT_NAME]);
            }

            if(values.Contains(CONTACT_PHONE)) {
                model.ContactPhone = Convert.ToString(values[CONTACT_PHONE]);
            }

            if(values.Contains(CONTACT_PHONE2)) {
                model.ContactPhone2 = Convert.ToString(values[CONTACT_PHONE2]);
            }

            if(values.Contains(WEBSITE)) {
                model.Website = Convert.ToString(values[WEBSITE]);
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