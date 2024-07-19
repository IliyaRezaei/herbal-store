using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PorbarWebApp.Data;
using PorbarWebApp.Models;

namespace PorbarWebApp.Controllers
{
    [Authorize(Roles ="user")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public OrdersController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string username)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
            User newUser = user;
            List<Order> orders = await _context.Orders.Where(u => u.UserId == user.Id && u.IsSold == false).Include(p=> p.Product).ToListAsync();
            return View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Details(string username, int productId)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
            
            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

            Order order = await _context.Orders.Where(u => u.UserId == user.Id).FirstOrDefaultAsync(o => o.IsSold != true && o.ProductId == product.Id);
            
            if (order != null)
            {
                if (order.ProductQuantity < product.Quantity)
                {
                    order.ProductQuantity += 1;
                }
            }
            else
            {
                await _context.Orders.AddAsync(new Order
                {
                    UserId = user.Id,
                    ProductId = productId,
                    IsSold = false,
                    ProductQuantity = 1,
                });
            }

            await _context.SaveChangesAsync();

            return RedirectToAction("Index","Home");
            
        }

        public async Task<IActionResult> Delete(int productId)
        {
            List<Order> deleteOrders = await _context.Orders.Where(o => o.ProductId == productId).ToListAsync();
            _context.Orders.RemoveRange(deleteOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Orders",new {username = _userManager.GetUserName(User)});
        }

        public async Task<IActionResult> CheckOut(string username)
        {
            User user = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedUserName == username.ToUpper());
            List<Order> orders = await _context.Orders.Where(u => u.UserId == user.Id && u.IsSold!= false).ToListAsync();

            foreach (Order order in orders)
            {
                order.IsSold = true;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> Cart()
        {
            var username = _userManager.GetUserName(HttpContext.User);
            return View();
        }
    }
}
