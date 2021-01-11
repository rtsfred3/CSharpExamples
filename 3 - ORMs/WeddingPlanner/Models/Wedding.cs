using System;
using System.Collections.Generic;

namespace WeddingPlanner.Models{
    public class Wedding{
        public int WeddingId{ get; set; }
        
        public string WedderOne{ get; set; }

        public string WedderTwo{ get; set; }

        public DateTime Date{ get; set; }

        public List<RSVPUsers> UsersRSVP{ get; set; }

        public int UserId{ get; set; }

        public User User{ get; set; }

        public Wedding(){
            UsersRSVP = new List<RSVPUsers>();
        }
    }
}