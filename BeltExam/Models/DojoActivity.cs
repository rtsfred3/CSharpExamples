using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeltExam.Models{
    public class DojoActivity{
        [Key]
        public int DojoActivityId{ get; set; }
        
        public string Title{ get; set; }

        public DateTime Date{ get; set; }

        public string Duration{ get; set; }

        public string Description{ get; set; }

        public int UserId{ get; set; }

        [ForeignKey(nameof(Models.User.UserId))]
        public User User{ get; set; }

        public List<UserActivity> UserActivity{ get; set; }

        public DojoActivity(){
            UserActivity = new List<UserActivity>();
        }
    }
}