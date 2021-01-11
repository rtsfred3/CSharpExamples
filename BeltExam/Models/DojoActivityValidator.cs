using System;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models{
    public class DojoActivityValidator{
        [Required]
        [MinLength(2, ErrorMessage = "Title is not long enough")]
        public string Title{ get; set; }

        [Required]
        public string Date{ get; set; }

        [Required]
        public int DurationTime{ get; set; }

        [Required]
        public string DurationUnits{ get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description is not long enough")]
        public string Description{ get; set; }
    }
}