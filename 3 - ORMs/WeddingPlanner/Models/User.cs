using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models{
    public class User{
        public int UserId{ get; set; }
        
        public string Name{ get; set; }

        public string Email{ get; set; }

        public string Password{ get; set; }

        public List<RSVPUsers> WeddingsRSVP{ get; set; }

        public User(){
            WeddingsRSVP = new List<RSVPUsers>();
        }
    }
}