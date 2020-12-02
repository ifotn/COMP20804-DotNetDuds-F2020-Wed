using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDuds.Controllers
{
    public class DummiesController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "This is a message from the controller";
            return View("Index");
        }
    }
}
