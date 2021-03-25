using GarbageCollector.Extra;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GarbageCollector.Models
{
    public class Customer 
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

        [Display(Name= "Regular Pickup Day")]
        [Required(ErrorMessage = "Pickup Day is Required")]
        public string RegularPickupDay { get; set; }

        [Display(Name= "One Time Pickup Day")]
        public DateTime OneTimePickupDay { get; set; }
        [Display(Name = "Suspending Start Day")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString= "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "Suspending End Day")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [DateGreaterThanAttribute(otherPropertyName = "StartDate", ErrorMessage = "End date must be greater than start date")]
        public DateTime? EndDate { get; set; }

        [Display(Name= "Bill Pay")]
        public int BillPay { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set;}
        public IdentityUser IdentityUser { get; set; }
        public int CustomerId { get; internal set; }

        public static implicit operator Customer(List<Customer> v)
        {
            throw new NotImplementedException();
        }
    }

    internal class DateGreaterThanAttribute : Attribute
    {
        public string otherPropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}
