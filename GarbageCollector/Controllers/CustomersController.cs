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

namespace GarbageCollector.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Customer Payment { get; set; }

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
           
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            //var applicationDbContext = _context.Customer.Include(c => c.IdentityUser);
            //return View(await applicationDbContext.ToListAsync());
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customer.Where(cu => cu.IdentityUserId == userId).ToList();
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
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(Customer customer)
        {
            try
            {
                customer.CustomerId = 0;
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customer.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var editting = await _context.Customer.FindAsync(id);
            return View(editting);
           
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Customer customer)
        {
           
                try
                {
                    _context.Customer.Update(customer);
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
            var billing = _context.Customer.Find(id);
            return View(billing);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChargeCustomer(int id, Customer customer)
        {
            try
            {
                var billing2 = _context.Customer.FindAsync(id);
                customer.BillPay += 7;
                _context.Customer.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            
        }
        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
