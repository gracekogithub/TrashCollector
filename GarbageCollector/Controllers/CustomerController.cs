using GarbageCollector.Data;
using GarbageCollector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GarbageCollector.Controllers
{
   
    
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }
        //[HttpGet]
        //public ActionResult Index()
        //{
        //    string todaysDate = DateTime.Now.ToShortDateString();
        //    //var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
        //    return Ok(todaysDate);
        //}

        

        // GET: CustomerController/Create
        [HttpGet]
        public ActionResult Create()
        {
            //var customer = _context.Customers.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        
    }
}
