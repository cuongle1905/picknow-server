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
    public class StoreProductViewsController : Controller
    {
        private MyDbContext _context;

        public StoreProductViewsController(MyDbContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int storeGroup, int storeProductGroup) {
            var storeproductviews = _context.StoreProductViews.Select(i => new {
                i.StoreGroup,
                i.StoreProductGroup,
                i.Price,
                i.Id,
                i.Name,
                i.Unit,
                i.Code,
                i.Brand,
                i.Origin,
                i.Size,
                i.Color,
                i.Description,
                i.StoreProductGroups
            }).Where(i => i.StoreGroup == storeGroup && i.StoreProductGroups.Contains("," + storeProductGroup + ","));

            //return Json(await DataSourceLoader.LoadAsync(storeproductviews, loadOptions));
            return Json(await storeproductviews.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetNColumns(int columns, int storeGroup, int storeProductGroup)
        {
            var storeproductviews = _context.StoreProductViews.Select(i => new {
                i.StoreGroup,
                i.StoreProductGroup,
                i.Price,
                i.Id,
                i.Name,
                i.Unit,
                i.Code,
                i.Brand,
                i.Origin,
                i.Size,
                i.Color,
                i.Description
            }).Where(i => i.StoreGroup == storeGroup && i.StoreProductGroup == storeProductGroup);

            var storeProducts = await storeproductviews.ToListAsync();
            var count = storeProducts.Count;
            var rows = count / columns;
            if (rows * columns < count)
                rows++;

            var nColumns = new List<NColumn>();
            var classType = typeof(NColumn);
            for(int row = 0; row < rows; row++)
            {
                var nColumn = new NColumn();
                for (int column = 0; column < columns; column++)
                {
                    var i = row * columns + column;
                    if (i >= count)
                        break;

                    var item = storeProducts[i];
                    var value = JsonConvert.SerializeObject(item);
                    classType.GetProperty("Col" + (column + 1)).SetValue(nColumn, value);
                }
                nColumns.Add(nColumn);
            }

            //return Json(await DataSourceLoader.LoadAsync(storeproductviews, loadOptions));
            return Json(nColumns);
        }

        [HttpPost]
        public async Task<IActionResult> Post(string values) {
            var model = new StoreProductView();
            var valuesDict = JsonConvert.DeserializeObject<IDictionary>(values);
            PopulateModel(model, valuesDict);

            if(!TryValidateModel(model))
                return BadRequest(GetFullErrorMessage(ModelState));

            var result = _context.StoreProductViews.Add(model);
            await _context.SaveChangesAsync();

            return Json(new { result.Entity.Id });
        }

        [HttpPut]
        public async Task<IActionResult> Put(long key, string values) {
            var model = await _context.StoreProductViews.FirstOrDefaultAsync(item => item.Id == key);
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
            var model = await _context.StoreProductViews.FirstOrDefaultAsync(item => item.Id == key);

            _context.StoreProductViews.Remove(model);
            await _context.SaveChangesAsync();
        }


        private void PopulateModel(StoreProductView model, IDictionary values) {
            string STORE_GROUP = nameof(StoreProductView.StoreGroup);
            string STORE_PRODUCT_GROUP = nameof(StoreProductView.StoreProductGroup);
            string PRICE = nameof(StoreProductView.Price);
            string ID = nameof(StoreProductView.Id);
            string NAME = nameof(StoreProductView.Name);
            string UNIT = nameof(StoreProductView.Unit);
            string CODE = nameof(StoreProductView.Code);
            string BRAND = nameof(StoreProductView.Brand);
            string ORIGIN = nameof(StoreProductView.Origin);
            string SIZE = nameof(StoreProductView.Size);
            string COLOR = nameof(StoreProductView.Color);
            string DESCRIPTION = nameof(StoreProductView.Description);

            if(values.Contains(STORE_GROUP)) {
                model.StoreGroup = Convert.ToInt32(values[STORE_GROUP]);
            }

            if(values.Contains(STORE_PRODUCT_GROUP)) {
                model.StoreProductGroup = Convert.ToInt32(values[STORE_PRODUCT_GROUP]);
            }

            if(values.Contains(PRICE)) {
                model.Price = values[PRICE] != null ? Convert.ToDecimal(values[PRICE], CultureInfo.InvariantCulture) : (decimal?)null;
            }

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