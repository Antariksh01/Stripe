using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Stripe.Models
{
    public class UserAccount
    {

        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [Display(Name ="Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage ="Please enter valid email address")]
        //We can also use [DataType(DataType.Email)] annotation
        public string EmailAddress { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Please confirm your password")]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        //[StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        public string ConfirmPassword { get; set; }

    }
}