using System;
using Microsoft.EntityFrameworkCore;

namespace ProjectWeek.Models{
    public class VideoContext : DbContext{
        public VideoContext(DbContextOptions<VideoContext> options) : base(options) { }

        public DbSet<Video> Video { get; set; }
    }
}