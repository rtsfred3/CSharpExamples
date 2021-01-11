using System;
using System.ComponentModel.DataAnnotations;

using BankAccounts.Models;

namespace BankAccounts.Models{
    public class Transactions{
        public int id { get; set; }
        
        [Required]
        public double amount{ get; set; }

        [Required]
        public DateTime date{ get; set; }

        [Required]
        public User user{ get; set; }
    }
}