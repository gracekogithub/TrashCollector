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
using GarbageCollector.Services;
using Customer = GarbageCollector.Models.Customer;

namespace GarbageCollector.Controllers
{
    [Authorize(Roles ="Customer")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        //private GoogleMapService _map;

        public CustomersController(ApplicationDbContext context /*GoogleMapService map*/)
        {
            _context = context;
            //_map = map;
        }

        // GET: Customers
        public IActionResult Index()
        {
            //ViewData["apiKeys"] = GoogleApiKeys.apiKey;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customers.Where(cu => cu.IdentityUserId == userId).ToList();
            if (customer.Count == 0)
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
            //ViewData["apiKeys"] = GoogleApiKeys.apiKey;
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // GET: Customers/Create
        [HttpGet]
        public IActionResult Create()
        {
         
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
                //customer.BillPay += 0;

                //var customerwithLatLng = _map.GetGeoCoding(customer);

                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
                return View();
            }
        }

        // GET: Customers/Edit/5
        public IActionResult Edit(int? id)
        {
            //ViewData["apiKeys"] = GoogleApiKeys.apiKey;
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            try
            {
                //var customerwithLatLng = _map.GetGeoCoding(customer);

                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("Error");
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
                customer.BillPay += 0;
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        //public IActionResult Delete(int id)
        //{
        //    var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
        //    return View(customer);
        //}

        //// POST: CustomerController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete(int id, Customer customer)
        //{
        //    try
        //    {

        //        _context.Customers.Remove(customer);
        //        _context.SaveChanges();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        Console.WriteLine("Error");
        //        return View();
        //    }
        //}
    }

   
}
