using GarbageCollector.Data;
using GarbageCollector.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollector.Controllers
{
   
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _employee;
        public EmployeeController(ApplicationDbContext employee)
        {
            _employee = employee;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var manage = _employee.Employee;
            return View(manage);
        }

        //// GET: EmployeeController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: EmployeeController/Create
        //public ActionResult Create()
        //{
            
        //    return View();
        //}

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee create)
        {
            try
            {
                _employee.Employee.Add(create);
                _employee.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var manage2 = _employee.Employee.Find(id);
            return View(manage2);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee edit)
        {
            try
            {
                _employee.Employee.Add(edit);
                _employee.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var manage3 = _employee.Employee.Find(id);
            return View(manage3);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee delete)
        {
            try
            {
                _employee.Employee.Add(delete);
                _employee.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
