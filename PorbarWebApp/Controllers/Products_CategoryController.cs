using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PorbarWebApp.Data;
using PorbarWebApp.Models;

namespace PorbarWebApp.Controllers
{
    public class Products_CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public Products_CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int categoryId)
        {
            var products = _context.Products.Where(p=> p.CategoryId == categoryId).Include(p => p.Category).ToList();
            return View(products);
        }
    }
}
