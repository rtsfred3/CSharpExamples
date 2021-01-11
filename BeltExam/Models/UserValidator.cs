using System;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models{
    public class UserValidator{
        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name is not long enough")]
        [RegularExpression("^[^1-9]*$", ErrorMessage = "Name cannot contain a number")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        public string Email{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password is not long enough")]
        [RegularExpression("^.*[a-zA-Z]*|.*\\d*|.*[^a-zA-Z\\d]*$", ErrorMessage = "Password must contain a letter, number, and a special character")]
        public string Password{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm Password is not long enough")]
        public string ConfirmPassword{ get; set; }
    }
}