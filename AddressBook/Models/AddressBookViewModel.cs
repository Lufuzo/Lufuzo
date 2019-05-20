using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class AddressBookViewModel
    { 
        [Key]
        public int AddressBookId { get; set; }
       
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [StringLength(50)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "BusinessPhoneNumber is required")]
        [StringLength(Int32.MaxValue, MinimumLength = 10)]
        [DisplayName("BusinessPhoneNumber")]
        public string BusinessPhoneNumber { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [StringLength(50)]
        [DisplayName("Location")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Department is required")]
        [StringLength(50)]
        [DisplayName("Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Email Address is required")]
        [DisplayName("EmailAddress")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Company is required")]
        [StringLength(50)]
        [DisplayName("Company")]
        public string Company { get; set; }
        [Required(ErrorMessage = "Elias is required")]
        [StringLength(50)]
        [DisplayName("Elias")]
        public string Elias { get; set; }
    }
}