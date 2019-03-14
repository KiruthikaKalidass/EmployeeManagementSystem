using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models
{
    public class EModel
    {
        public bool Check { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "EmployeeName is required")]
    
        public string EmployeeName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
       
        

        [Required(ErrorMessage = "DateOfBirth is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "DateofJoining is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOJ { get; set; }

       

        [Required(ErrorMessage = "Blood Group is required")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Qualification is required")]
       
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Designation is required")]
       
        public string Designation { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
    
        public int PhoneNumber { get; set; }
        [Required(ErrorMessage = "emailid is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }
         [Required(ErrorMessage ="Gender is Required")]
         [Display(Name ="Gender")]
         public Nullable<bool> Gender { get; set; }
        
    }
    
}