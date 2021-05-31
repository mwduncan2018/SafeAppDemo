using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeAppDemo.DataStore;

namespace SafeAppDemo.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult ResetDb()
        {
            Table.Initialize();
            return RedirectToAction("Index", "ProductList");
        }
    }
}
