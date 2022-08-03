using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MainView()
        {
            return View();
        }
    }
}
