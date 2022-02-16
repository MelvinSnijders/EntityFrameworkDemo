using EFDemo.Model;
using System.Linq;
using System.Threading.Tasks;

namespace EFDemo.DAL.Repositories
{
    public class CourseRepository : Repository<Course, CourseContext>, ICourseRepository
    {
        public CourseRepository(CourseContext context) : base(context) { }

        public Course GetCourse(int id) => FindByCondition(c => c.Id == id).FirstOrDefault();

        public Task<PagedList<Course>> GetCourses(int pageNumber, int pageSize)
        {
            return Task.FromResult(PagedList<Course>.GetPagedList(FindAll().OrderBy(c => c.Code), pageNumber, pageSize));
        }
    }
}
