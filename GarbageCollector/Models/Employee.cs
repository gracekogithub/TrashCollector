﻿using GarbageCollector.Extra;
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
        public int Id { get; set; }

        [Display(Name = "Fist Name")]
        [Required(ErrorMessage = "Fist Name is Required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }
       

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip Code is Required")]
        public int ZipCode { get; set; }

        [Display(Name = "Customer Pickup Day")]
        
        public DateTime RegularPickupDay { get; set; }

        [Display(Name = "One Time Pickup Day")]
        public DateTime OneTimePickupDay { get; set; }

        [Display(Name = "Bill Pay")]
        public int BillPay { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }

}
