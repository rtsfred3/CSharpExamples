using System;

namespace WeddingPlanner.Models{
    public class RSVPUsers{
        public int RSVPUsersId{ get; set; }

        public int UserId{ get; set; }
        public User User{ get; set; }

        public int WeddingId{ get; set; }
        public Wedding Wedding{ get; set; }
    }
}