using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetDuds.Data;
using DotNetDuds.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        // GET: /Shop/Browse/3
        public IActionResult Browse(int id)
        {
            // query the db for the products in the selected category
            var products = _context.Products.Include(p => p.Category).Where(p => p.CategoryId == id).OrderBy(p => p.Name).ToList();

            // get the Category name for display in the page heading
            ViewBag.Category = products[0].Category.Name;
            //ViewBag.Category = _context.Categories.Find(id).Name.ToString();

            // load the Browse view & pass the list of products for display
            return View(products);
        }

        // POST: /Shop/AddToCart
        [HttpPost]
        public IActionResult AddToCart(int ProductId, int Quantity)
        {
            // look up the current product price
            var price = _context.Products.Find(ProductId).Price;

            // set the customer
            var customerId = GetCustomerId();

            // create /populate a new cart object 
            var cart = new Cart
            {
                ProductId = ProductId,
                Quantity = Quantity,
                Price = price,
                CustomerId = customerId,
                DateCreated = DateTime.Now
            };

            // save to the Carts table in the db
            _context.Carts.Add(cart);
            _context.SaveChanges();

            // redirect to Cart page
            return RedirectToAction("Cart");
        }

        // check session for existing Session ID.  If none exists, first create it then send it back.
        private string GetCustomerId()
        {
            // check if there is already a CustomerId session variable
            if (HttpContext.Session.GetString("CustomerId") == null)
            {
                // this is the 1st item in this user's cart; generate Guid and store in session variable
                HttpContext.Session.SetString("CustomerId", Guid.NewGuid().ToString());
            }

            return HttpContext.Session.GetString("CustomerId");
        }
    }
}
