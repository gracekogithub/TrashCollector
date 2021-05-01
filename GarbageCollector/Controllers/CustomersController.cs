using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarbageCollector.Data;
using GarbageCollector.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace GarbageCollector.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(cu => cu.IdentityUserId == userId).ToList();
            if (customer == null)
            {
                return RedirectToAction(nameof(Create));
            }
            else
            {
                return View(customer);
            }
        }

        // GET: Customers/Details/5
        public IActionResult Details(int id)
        {
            var customer = _context.Customers.Where(ct => ct.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: Customers/Create
        [HttpGet]
        public IActionResult Create()
        {
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public IActionResult Create(Customer customer)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            var editting = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(editting);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Customer customer)
        {
                try
                {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
                catch
                {
                    return View();
                }
        }

        public IActionResult BillingCustomer(int id)
        {
            var billing = _context.Customers.Find(id);
            return View(billing);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChargeCustomer(int id, Customer customer)
        {
            try
            {
                var billing2 = _context.Customers.FindAsync(id);
                customer.BillPay += 7;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
