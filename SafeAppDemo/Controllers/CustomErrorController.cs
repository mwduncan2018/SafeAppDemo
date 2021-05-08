using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SafeAppDemo.Controllers
{
    public class CustomErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
