using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models{
    public class User{
        [Key]
        public int UserId{ get; set; }
        
        public string Name{ get; set; }

        public string Email{ get; set; }

        public string Password{ get; set; }

        public List<UserActivity> UserActivity{ get; set; }

        public User(){
            UserActivity = new List<UserActivity>();
        }
    }
}