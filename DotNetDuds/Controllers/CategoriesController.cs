using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetDuds.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDuds.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            // use the Category model to create & populate a list of 10 mock category objects for display
            // create an empty list of type Category
            var categories = new List<Category>();

            // use a loop to make 10 fake objects
            for (var i = 1; i <= 10; i++)
            {
                categories.Add(new Category() { Id = i, Name = "Category " + i.ToString() });
            }

            // pass the populated list to the view for display
            return View(categories);
        }

        public IActionResult Browse(string category)
        {
            // pass the incoming category back to the browse view using the ViewBag container object
            ViewBag.category = category;
            return View();
        }
    }
}
