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
    [Authorize(Roles = "Employee")]
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employees
        public IActionResult Index(int? value, Customer customer)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employees.Where(cu => cu.IdentityUserId == userId).SingleOrDefault();
         
            if (employee == null)
            {
                return RedirectToAction(nameof(Create));
            }
            string currentDayOfWeek = DateTime.Now.DayOfWeek.ToString();
            var customersWithSameZip = _context.Customers.Where(c => c.ZipCode == employee.PickUpAreaZipCode).ToList();
            var customersWithSameDay = customersWithSameZip.Where(c => c.RegularPickupDay == currentDayOfWeek).ToList();
            var customersWithSuspendedDays = customersWithSameDay.Where(c => c.StartDate.ToString() == currentDayOfWeek && c.EndDate.ToString() == currentDayOfWeek).ToList();
            var NewSet = customersWithSameDay.Except(customersWithSuspendedDays);
            return View(NewSet);
        }

        // GET: Employees/Details/5
       

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // POST: Employees/Create
       

        // GET: Employees/Edit/5
        public IActionResult Edit(int? id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Employees/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Customer customer)
        {
            try
            {
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int? id)
        {
            var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Customer customer)
        {
            try
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Charge(int id)
        {
            try
            {
                var customer = _context.Customers.Where(e => e.CustomerId == id).FirstOrDefault();
                customer.BillPay += 25;
                customer.LastPickupDay = DateTime.Now;
                customer.IsPickupConfirmed = "Yes";
                _context.Customers.Update(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return View();
            }
        }
    }
}
