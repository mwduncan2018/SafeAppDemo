using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeAppDemo.DataStore;
using SafeAppDemo.ViewModels;

namespace SafeAppDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductListApiController : ControllerBase
    {
        // GET: api/<ProductListApi>
        [HttpGet]
        public ActionResult Get()
        {
            IList<FuzzyViewModel> viewModelList = new List<FuzzyViewModel>();
            foreach (var product in Table.Products)
            {
                FuzzyViewModel fuzzyViewModel = new FuzzyViewModel
                {
                    Id = product.Id,
                    Manufacturer = product.Manufacturer,
                    Model = product.Model,
                    NumberInStock = product.NumberInStock,
                    Price = product.Price,
                };
                fuzzyViewModel.IsOnWatchList = Table.WatchListEntries
                    .Where(e => e.Manufacturer == product.Manufacturer && e.Model == product.Model)
                    .Count() != 0 ? true : false;
                if (fuzzyViewModel.IsOnWatchList == false)
                {
                    // If either Manufacturer or Model is a match, fuzzy match is true
                    fuzzyViewModel.IsFuzzyMatch = Table.WatchListEntries
                        .Where(f => f.Manufacturer == product.Manufacturer || f.Model == product.Model)
                        .Count() != 0 ? true : false;
                }
                viewModelList.Add(fuzzyViewModel);
            }
            return Ok(viewModelList
                .OrderBy(w => w.Manufacturer)
                .ThenBy(x => x.Model)
                .ThenBy(y => y.Price)
                .ThenBy(z => z.Id)
                .ToList());
        }

        // GET api/<ProductListApi>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            IList<FuzzyViewModel> viewModelList = new List<FuzzyViewModel>();
            foreach (var product in Table.Products)
            {
                FuzzyViewModel fuzzyViewModel = new FuzzyViewModel
                {
                    Id = product.Id,
                    Manufacturer = product.Manufacturer,
                    Model = product.Model,
                    NumberInStock = product.NumberInStock,
                    Price = product.Price,
                };
                fuzzyViewModel.IsOnWatchList = Table.WatchListEntries
                    .Where(e => e.Manufacturer == product.Manufacturer && e.Model == product.Model)
                    .Count() != 0 ? true : false;
                if (fuzzyViewModel.IsOnWatchList == false)
                {
                    // If either Manufacturer or Model is a match, fuzzy match is true
                    fuzzyViewModel.IsFuzzyMatch = Table.WatchListEntries
                        .Where(f => f.Manufacturer == product.Manufacturer || f.Model == product.Model)
                        .Count() != 0 ? true : false;
                }
                viewModelList.Add(fuzzyViewModel);
            }
            return Ok(viewModelList.FirstOrDefault(x => x.Id == id));
            
        }

        // POST api/<ProductListApi>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductListApi>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductListApi>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
