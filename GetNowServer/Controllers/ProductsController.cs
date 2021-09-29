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
    public class ProductsController : Controller
    {
        private MyDbContext _context;

        public ProductsController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
            var products = _context.Products.Select(i => new {
                i.Id,
                i.Name,
                i.Unit,
                i.Code,
                i.Brand,
                i.Origin,
                i.Size,
                i.Color,
                i.Description
            });

            // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
            // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
            // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
            // loadOptions.PrimaryKey = new[] { "Id" };
            // loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(products, loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new Product();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.Products.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(long key, string values) {
            var model = await _context.Products.FirstOrDefaultAsync(item => item.Id == key);
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
        public async Task Delete(long key) {
            var model = await _context.Products.FirstOrDefaultAsync(item => item.Id == key);

            _context.Products.Remove(model);
            await _context.SaveChangesAsync();
        }


        [HttpGet]
        public async Task<IActionResult> BrandsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Brands
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> ColorsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Colors
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> OriginsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Origins
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> SizesLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Sizes
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        [HttpGet]
        public async Task<IActionResult> UnitsLookup(DataSourceLoadOptions loadOptions) {
            var lookup = from i in _context.Units
                         orderby i.Name
                         select new {
                             Value = i.Id,
                             Text = i.Name
                         };
            return Json(await DataSourceLoader.LoadAsync(lookup, loadOptions));
        }

        private void PopulateModel(Product model, IDictionary values) {
            string ID = nameof(Product.Id);
            string NAME = nameof(Product.Name);
            string UNIT = nameof(Product.Unit);
            string CODE = nameof(Product.Code);
            string BRAND = nameof(Product.Brand);
            string ORIGIN = nameof(Product.Origin);
            string SIZE = nameof(Product.Size);
            string COLOR = nameof(Product.Color);
            string DESCRIPTION = nameof(Product.Description);

            if(values.Contains(ID)) {
                model.Id = Convert.ToInt64(values[ID]);
            }

            if(values.Contains(NAME)) {
                model.Name = Convert.ToString(values[NAME]);
            }

            if(values.Contains(UNIT)) {
                model.Unit = Convert.ToInt32(values[UNIT]);
            }

            if(values.Contains(CODE)) {
                model.Code = Convert.ToString(values[CODE]);
            }

            if(values.Contains(BRAND)) {
                model.Brand = values[BRAND] != null ? Convert.ToInt32(values[BRAND]) : (int?)null;
            }

            if(values.Contains(ORIGIN)) {
                model.Origin = values[ORIGIN] != null ? Convert.ToInt16(values[ORIGIN]) : (short?)null;
            }

            if(values.Contains(SIZE)) {
                model.Size = values[SIZE] != null ? Convert.ToInt32(values[SIZE]) : (int?)null;
            }

            if(values.Contains(COLOR)) {
                model.Color = values[COLOR] != null ? Convert.ToInt16(values[COLOR]) : (short?)null;
            }

            if(values.Contains(DESCRIPTION)) {
                model.Description = Convert.ToString(values[DESCRIPTION]);
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