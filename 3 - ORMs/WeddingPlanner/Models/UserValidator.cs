using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
    public class UserValidator{
        [Required]
        [MinLength(2, ErrorMessage = "Name is not long enough")]
        public string Name{ get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(2, ErrorMessage = "Password is not long enough")]
        public string Password{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password is not long enough")]
        public string ConfirmPassword{ get; set; }
    }
}