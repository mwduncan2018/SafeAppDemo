using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SafeAppDemo.DataStore;
using SafeAppDemo.Models;

namespace SafeAppDemo.Controllers
{
    public class WatchListController : Controller
    {
        // GET: WatchListController
        public ActionResult Index()
        {
            return View(Table.WatchListEntries.OrderBy(x => x.Manufacturer).ThenBy(y => y.Model).ThenBy(z => z.Id).ToList());
        }

        // GET: WatchListController/Details/5
        public ActionResult Details(int id)
        {
            var watchListEntry = Table.WatchListEntries.FirstOrDefault(x => x.Id == id);
            if (watchListEntry == null)
            {
                return RedirectToAction("Index", "CustomError");
            }
            else
            {
                return View(watchListEntry);
            }
        }

        // GET: WatchListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WatchListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection form)
        {
            try
            {
                Table.WatchListEntries.Add(new WatchListEntry(
                                                    Table.WatchListEntryCount,
                                                    form["Manufacturer"],
                                                    form["Model"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // GET: WatchListController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                return View(Table.WatchListEntries.FirstOrDefault(x => x.Id == id));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }

        }

        // POST: WatchListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection form)
        {
            try
            {
                Table.WatchListEntries = Table.WatchListEntries.Where(x => x.Id != id).ToList();
                Table.WatchListEntries.Add(new WatchListEntry(
                                                    Table.WatchListEntryCount,
                                                    form["Manufacturer"],
                                                    form["Model"]));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }

        // GET: WatchListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(Table.WatchListEntries.FirstOrDefault(x => x.Id == id));
        }

        // POST: WatchListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Table.WatchListEntries = Table.WatchListEntries.Where(x => x.Id != id).ToList();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Index", "CustomError");
            }
        }
    }
}
