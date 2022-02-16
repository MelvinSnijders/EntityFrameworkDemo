using EFDemo.Model;
using System.Threading.Tasks;

namespace EFDemo.DAL.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        public Course GetCourse(int id);
        public Task<PagedList<Course>> GetCourses(int pageNumber, int pageSize);
    }
}
