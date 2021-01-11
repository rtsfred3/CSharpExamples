using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models{
    public class UserActivity{
        [Key]
        public int UserActivityId{ get; set; }

        public int UserId{ get; set; }
        
        [ForeignKey(nameof(Models.User.UserId))]
        public User User{ get; set; }

        public int DojoActivityId{ get; set; }

        [ForeignKey(nameof(Models.DojoActivity.DojoActivityId))]
        public DojoActivity DojoActivity{ get; set; }
    }
}