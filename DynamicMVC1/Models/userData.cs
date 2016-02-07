using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DynamicMVC1.Custom;

namespace DynamicMVC1.Models
{
    public class userData
    {
        [Key]
        public int id { get; set; }


        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "A first name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please only use letters to write your name.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "A last name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Please only use letters to write your name.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your City's name should only be composed of letters.")]
        [Display(Name = "City ")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Your State's name should only be composed of letters.")]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        [RegularExpression(@"\d{5}-?(\d{4})?$", ErrorMessage = "Enter a valid Zip Code")]
        public int ZipCode { get; set; }

        [RegularExpression(@"\d{10}", ErrorMessage = "Enter a 10 digit phone number")]
        [Required]
        [Phone]
        [Display(Name = "Phone #")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "A valid email address is required.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //
        public DateTime MinDate { get { return DateTime.MinValue; } }
        public DateTime MaxDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        //[ValidBirthDate(ErrorMessage = "Birth Date can not be greater than current date")]
        [DateValidator("MinDate", "MaxDate", ErrorMessage = "Value must be between {0} and {1}")]
        public DateTime Date_of_Birth { get; set; }



        //

        [DataType(DataType.MultilineText)]
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}