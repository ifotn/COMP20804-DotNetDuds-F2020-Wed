using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetDuds.Data;
using Microsoft.AspNetCore.Mvc;

namespace DotNetDuds.Controllers
{
    public class ShopController : Controller
    {
        // db connection
        private readonly ApplicationDbContext _context;

        // constructor that accepts a db context object
        public ShopController(ApplicationDbContext context)
        {
            // instantiate an instance of our db connection when this class is instantiated
            _context = context;
        }

        public IActionResult Index()
        {
            // use the db context and Categories DbSet to fetch a list from the db
            var categories = _context.Categories.OrderBy(c => c.Name).ToList();

            // pass the categories data to the view for display to the shopper
            return View(categories);
        }
    }
}
