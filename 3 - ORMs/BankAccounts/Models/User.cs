using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccounts.Models{
    public class User{
        public int id { get; set; }
        
        [Required]
        public string first_name{ get; set; }

        [Required]
        public string last_name{ get; set; }

        [Required]
        public string email{ get; set; }

        [Required]
        public string password{ get; set; }
    }
}