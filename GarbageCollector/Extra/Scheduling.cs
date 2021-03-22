using GarbageCollector.Data;
using GarbageCollector.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollector.Extra
{
    public class Scheduling
    {
        public class scheduling
        {
            public class Scheduling : IScheduling
            {
                private readonly ApplicationDbContext _schedule;
                public Scheduling(ApplicationDbContext schedule)
                {
                    _schedule = schedule;
                }
                public List<Employee> GetEmployeeList()
                {
                    var employee = (from user in _schedule.Users 
                                    join userRoles in _schedule.UserRoles on user.Id equals userRoles.UserId
                                    join roles in _schedule.Roles.Where(e=>e.Name==Extra.Employee) on userRoles.RoleId equals roles.Id
                                    select new Employee 
                                    { 
                                        //Id = _schedule.Id,
                                        //Name = _schedule.Name
                                    }).ToList();
                    return employee;
                }
                //public List<Customer> GetCustomerList()
                //{
                //    var customer = (from user in _schedule.Users
                //                    join userRoles in _schedule.UserRoles on user.Id equals userRoles.UserId
                //                    join roles in _schedule.Roles.Where(e => e.Name == Extra.Customer) on userRoles.RoleId equals roles.Id
                //                    select new Employee
                //                    {
                //                        //Id = _schedule.Id,
                //                        //Name = _schedule.Name
                //                    }).ToList();
                //    return customer;
                //}

                void IScheduling.GetEmployeeList()
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
