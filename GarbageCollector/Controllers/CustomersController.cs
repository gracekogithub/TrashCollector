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
            //Payment = new List<Customer>()
            //{
            //    Payment
            //};
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
        //public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Address,ZipCode,RegularPickupDay,OneTimePickupDay,BillPay,IdentityUserId")] Customer customer)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(customer);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
        //    return View(customer);
        //}
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
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var customer = await _context.Customer.FindAsync(id);
            //if (customer == null)
            //{
            //    return NotFound();
            //}
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Customer customer)
        {
            //if (id != customer.Id)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
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
                //try
                //{
                //    _context.Update(customer);
                //    _context.SaveChanges();
                //    return RedirectToAction(nameof(Index));
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CustomerExists(customer.Id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //return RedirectToAction(nameof(Index));
            //}
            //ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", customer.IdentityUserId);
            //return View(customer);
        }

        // GET: Customers/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var customer = await _context.Customer
        //        .Include(c => c.IdentityUser)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (customer == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(customer);
        //}

        //// POST: Customers/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var customer = await _context.Customer.FindAsync(id);
        //    _context.Customer.Remove(customer);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
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
