using Microsoft.EntityFrameworkCore;
using flowdown_backend.Models;

namespace flowdown_backend
{
    public class LessonContext : DbContext
    {
        public LessonContext(DbContextOptions<LessonContext> options) : base(options){ }
        
        public DbSet<Models.Lesson> Lessons { get;set; }
        
        public DbSet<flowdown_backend.Models.AssignedActivity> AssignedActivity { get; set; }

    }
}
