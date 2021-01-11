using System;
using System.ComponentModel.DataAnnotations;

namespace RESTauranter.Models{
    public class Review{
        public int id{ get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string restaurant { get; set; }

        [Required]
        public int stars { get; set; }

        [Required]
        public DateTime date { get; set; }

        [Required]
        [MinLength(10)]
        public string review { get; set; }
    }
}