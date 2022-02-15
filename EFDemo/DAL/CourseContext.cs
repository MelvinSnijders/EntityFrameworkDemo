using EFDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.DAL
{
    public class CourseContext : DbContext
    {

        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<Course> Course { get; set; }

    }
}
