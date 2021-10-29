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
    public class ProductViewsController : Controller
    {
        private MyDbContext _context;

        public ProductViewsController(MyDbContext context) {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get(string name, int storeGroupId)
        {
            var products = _context.ProductViews.FromSqlRaw("call proc_search_product_for_store_group({0}, {1});", name, storeGroupId); //.Where(i => i.Name.Contains(name)).Take(20);
            return Json(await products.ToListAsync());
        }

        //[HttpGet]
        //public async Task<IActionResult> Get(DataSourceLoadOptions loadOptions) {
        //    var productviews = _context.ProductViews.Select(i => new {
        //        i.Id,
        //        i.Name,
        //        i.Unit,
        //        i.Code,
        //        i.Brand,
        //        i.Origin,
        //        i.Size,
        //        i.Color,
        //        i.Description,
        //        i.Image,
        //        i.ImageFile
        //    });

        //    // If you work with a large amount of data, consider specifying the PaginateViaPrimaryKey and PrimaryKey properties.
        //    // In this case, keys and data are loaded in separate queries. This can make the SQL execution plan more efficient.
        //    // Refer to the topic https://github.com/DevExpress/DevExtreme.AspNet.Data/issues/336.
        //    // loadOptions.PrimaryKey = new[] { "Id" };
        //    // loadOptions.PaginateViaPrimaryKey = true;

        //    return Json(await DataSourceLoader.LoadAsync(productviews, loadOptions));
        //}

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new ProductView();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.ProductViews.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(long key, string values) {
            var model = await _context.ProductViews.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.ProductViews.FirstOrDefaultAsync(item => item.Id == key);

            _context.ProductViews.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(ProductView model, IDictionary values) {
            string ID = nameof(ProductView.Id);
            string NAME = nameof(ProductView.Name);
            string UNIT = nameof(ProductView.Unit);
            string CODE = nameof(ProductView.Code);
            string BRAND = nameof(ProductView.Brand);
            string ORIGIN = nameof(ProductView.Origin);
            string SIZE = nameof(ProductView.Size);
            string COLOR = nameof(ProductView.Color);
            string DESCRIPTION = nameof(ProductView.Description);
            string IMAGE = nameof(ProductView.Image);
            string IMAGE_FILE = nameof(ProductView.ImageFile);

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

            if(values.Contains(IMAGE)) {
                model.Image = values[IMAGE] != null ? Convert.ToInt32(values[IMAGE]) : (int?)null;
            }

            if(values.Contains(IMAGE_FILE)) {
                model.ImageFile = Convert.ToString(values[IMAGE_FILE]);
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