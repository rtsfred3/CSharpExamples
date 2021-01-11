using System;
using Microsoft.EntityFrameworkCore;

using WeddingPlanner.Models;

namespace WeddingPlanner.Models{
    public class UserContext : DbContext{
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Wedding> Weddings{ get; set; }
        public DbSet<RSVPUsers> RSVPUsers{ get; set; }
    }
}