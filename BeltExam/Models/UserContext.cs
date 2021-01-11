using System;
using Microsoft.EntityFrameworkCore;

using BeltExam.Models;

namespace BeltExam.Models{
    public class UserContext : DbContext{
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<DojoActivity> DojoActivity{ get; set; }
        public DbSet<UserActivity> UserActivity{ get; set; }
    }
}