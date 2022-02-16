using EFDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace EFDemo.DAL
{
    public class CourseContext : DbContext
    {

        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }

        public DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasData(new Course(1, "DW", "Discrete Wiskunde"));
            modelBuilder.Entity<Course>().HasData(new Course(2, "GP", "Games Programming"));
            modelBuilder.Entity<Course>().HasData(new Course(3, "ANA1", "Analyse 1"));
            modelBuilder.Entity<Course>().HasData(new Course(4, "ANA2", "Analyse 2"));
            modelBuilder.Entity<Course>().HasData(new Course(5, "C#", "C-sharp"));
            modelBuilder.Entity<Course>().HasData(new Course(6, "GESP", "Gesprekken in Organisaties"));
            modelBuilder.Entity<Course>().HasData(new Course(7, "WP", "Web programmeren")); 
            modelBuilder.Entity<Course>().HasData(new Course(8, "PYT", "Python")); 
            modelBuilder.Entity<Course>().HasData(new Course(9, "JAV", "Java programmeren"));
            modelBuilder.Entity<Course>().HasData(new Course(10, "ISEC", "Inleiding Security"));
        }

    }
}
