using System;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models{
    public class WeddingValidator{
        [Required]
        [MinLength(2, ErrorMessage = "WedderOne is not long enough")]
        public string WedderOne{ get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "WedderTwo is not valid")]
        public string WedderTwo{ get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string Date{ get; set; }
    }
}