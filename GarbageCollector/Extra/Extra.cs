using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollector.Extra
{
    public static class Extra
    {
        public static string Admin = "Admin";
        public static string Customer = "Customer";
        public static string Employee = "Employee";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value=Extra.Admin,Text=Extra.Admin},
                new SelectListItem{Value=Extra.Customer,Text=Extra.Customer},
                new SelectListItem{Value=Extra.Employee,Text=Extra.Employee},
            };
        }
        
    }
}
