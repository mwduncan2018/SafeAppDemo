using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeAppDemo.DataStore;
using SafeAppDemo.Models;
using SafeAppDemo.ViewModels;

namespace SafeAppDemo.Controllers
{
    public class ProductListController : Controller
    {
        public ActionResult Index()
        {
            IList<ProductViewModel> viewModelList = new List<ProductViewModel>();
            foreach (var product in Table.Products)
            {
                ProductViewModel productViewModel = new ProductViewModel
                {
                    Id = product.Id,
                    Manufacturer = product.Manufacturer,
                    Model = product.Model,
                    NumberInStock = product.NumberInStock,
                    Price = product.Price,
                };
                productViewModel.IsOnWatchList = Table.WatchListEntries
                    .Where(e => e.Manufacturer == product.Manufacturer && e.Model == product.Model)
                    .Count() != 0 ? true : false;
                viewModelList.Add(productViewModel);
            }
            return View(viewModelList.OrderBy(w => w.Manufacturer).ThenBy(x => x.Model).ThenBy(y => y.Price).ThenBy(z => z.Id).ToList());
        }

        public ActionResult Fuzzy()
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
            return View(viewModelList.OrderBy(w => w.Manufacturer).ThenBy(x => x.Model).ThenBy(y => y.Price).ThenBy(z => z.Id).ToList());
        }

        // GET: SampleController/Details/5
        public ActionResult Details(int id)
        {
            var product = Table.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                return RedirectToAction("Index", "CustomError");
            }
            else
            {
                return View(product);
            }
        }

        // GET: SampleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SampleController/Create
        //public ActionResult Create(IFormCollection collection)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            try
            {
                Table.Products.Add(new Product(
                                            Table.ProductCount,
                                            form["Manufacturer"],
                                            form["Model"],
                                            Convert.ToDouble(form["Price"]),
                                            Convert.ToInt32(form["NumberInStock"])));
                return RedirectToAction("Index", "ProductList");
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // GET: SampleController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(Table.Products.FirstOrDefault(x => x.Id == id));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // POST: SampleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection form)
        {
            try
            {
                Table.Products = Table.Products.Where(x => x.Id != id).ToList();
                Table.Products.Add(new Product(
                                            Table.ProductCount,
                                            form["Manufacturer"],
                                            form["Model"],
                                            Convert.ToDouble(form["Price"]),
                                            Convert.ToInt32(form["NumberInStock"])));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // GET: SampleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Table.Products.FirstOrDefault(x => x.Id == id));
        }

        // POST: SampleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Table.Products = Table.Products.Where(x => x.Id != id).ToList();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }
    }
}
