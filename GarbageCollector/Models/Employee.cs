using GarbageCollector.Extra;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollector.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Fist Name")]
        [Required(ErrorMessage = "Fist Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Display(Name = "Assigned Pickup Area Zip Code")]
        public int PickUpAreaZipCode { get; set; }


     

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }

}
